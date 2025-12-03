using System;
using System.Configuration;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace AMS2ChEd
{
    public partial class OptionsWindow : Window
    {
        private const string AMS2_REGISTRY_PATH = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 1066890";
        private const string DEFAULT_STEAM_PATH = @"C:\Program Files (x86)\Steam\steamapps\common\Automobilista 2";
        private const string SETTINGS_KEY = "AMS2FolderPath";

        public OptionsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Try to get AMS2 folder from saved settings first
            string savedPath = GetSavedPath();

            if (!string.IsNullOrEmpty(savedPath) && Directory.Exists(savedPath))
            {
                AMS2FolderTextBox.Text = savedPath;
            }
            else
            {
                // Try to find AMS2 installation from Steam registry
                string ams2Path = GetAMS2InstallPath();
                AMS2FolderTextBox.Text = ams2Path;
            }
        }

        private string GetSavedPath()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[SETTINGS_KEY] != null)
                {
                    return config.AppSettings.Settings[SETTINGS_KEY].Value;
                }
            }
            catch
            {
                // Ignore errors, will use default path
            }
            return string.Empty;
        }

        private void SavePath(string path)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[SETTINGS_KEY] != null)
                {
                    config.AppSettings.Settings[SETTINGS_KEY].Value = path;
                }
                else
                {
                    config.AppSettings.Settings.Add(SETTINGS_KEY, path);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error saving settings: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetAMS2InstallPath()
        {
            try
            {
                // Try to get from registry
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(AMS2_REGISTRY_PATH))
                {
                    if (key != null)
                    {
                        string installLocation = key.GetValue("InstallLocation") as string;
                        if (!string.IsNullOrEmpty(installLocation) && Directory.Exists(installLocation))
                        {
                            return installLocation;
                        }
                    }
                }

                // Try common Steam library locations
                string[] commonPaths = new[]
                {
                    DEFAULT_STEAM_PATH,
                    @"D:\SteamLibrary\steamapps\common\Automobilista 2",
                    @"E:\SteamLibrary\steamapps\common\Automobilista 2",
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                        @"Steam\steamapps\common\Automobilista 2")
                };

                foreach (var path in commonPaths)
                {
                    if (Directory.Exists(path))
                    {
                        return path;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error finding AMS2 installation: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return DEFAULT_STEAM_PATH;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = "Select AMS2 Installation Folder",
                ShowNewFolderButton = false
            };

            if (!string.IsNullOrEmpty(AMS2FolderTextBox.Text))
            {
                dialog.SelectedPath = AMS2FolderTextBox.Text;
            }

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AMS2FolderTextBox.Text = dialog.SelectedPath;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = AMS2FolderTextBox.Text.Trim();

            if (string.IsNullOrEmpty(folderPath))
            {
                System.Windows.MessageBox.Show("Please specify the AMS2 folder path.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                var result = System.Windows.MessageBox.Show(
                    "The specified folder does not exist. Do you want to save it anyway?",
                    "Folder Not Found",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            // Save to configuration
            SavePath(folderPath);

            System.Windows.MessageBox.Show("Settings saved successfully!", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}