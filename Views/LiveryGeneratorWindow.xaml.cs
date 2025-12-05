using AMS2ChEd.Models;
using AMS2LiveryService;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace AMS2ChEd
{
    /// <summary>
    /// Standalone window for testing AMS2 Livery Generator
    /// Can be opened from your existing application with: new LiveryGeneratorWindow().ShowDialog();
    /// </summary>
    public partial class LiveryGeneratorWindow : Window
    {
        private ObservableCollection<RaceEntryViewModel> entryList;
        private Func<string, string, string, string> ddsComposer;

        /// <summary>
        /// Initialize with default DDS composer (just copies files)
        /// </summary>
        public LiveryGeneratorWindow()
        {
            InitializeComponent();
            Initialize(null);
        }

        /// <summary>
        /// Initialize with custom DDS composer function
        /// </summary>
        /// <param name="customDdsComposer">Function to compose DDS files: (baseFile, sponsorFile, outputPath) => outputPath</param>
        public LiveryGeneratorWindow(Func<string, string, string, string> customDdsComposer)
        {
            InitializeComponent();
            Initialize(customDdsComposer);
        }

        private void Initialize(Func<string, string, string, string> customDdsComposer)
        {
            entryList = new ObservableCollection<RaceEntryViewModel>();
            dgEntryList.ItemsSource = entryList;

            // Set DDS composer
            if (customDdsComposer != null)
            {
                ddsComposer = customDdsComposer;
            }
            else
            {
                // Default: just copy base file (replace with your actual DDS composition)
                ddsComposer = (baseFile, sponsorFile, outputPath) =>
                {
                    LogOutput($"  DDS: {Path.GetFileName(baseFile)} + {Path.GetFileName(sponsorFile)}");
                    HelmetComposer.Compose(baseFile, sponsorFile, outputPath);
                    return outputPath;
                };
            }

            AddSampleData();
        }

        #region Browse Buttons

        private void BrowseDriversJson_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                dialog.Title = "Select Drivers JSON File";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDriversJson.Text = dialog.FileName;
                }
            }
        }

        private void BrowseSeasonJson_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                dialog.Title = "Select Season JSON File";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtSeasonJson.Text = dialog.FileName;
                }
            }
        }

        private void BrowseAms2Root_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select AMS2 Root Directory (contains UserData and Vehicles folders)";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtAms2Root.Text = dialog.SelectedPath;
                }
            }
        }

        private void BrowseDriversDir_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Drivers Directory (contains base_helmet_liveries/ and drivers.json)";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDriversDir.Text = dialog.SelectedPath;
                }
            }
        }

        private void BrowseSeasonDir_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Season Directory (e.g., Seasons/1996) containing static_assets/, car_liveries/, helmet_sponsors/";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtSeasonDir.Text = dialog.SelectedPath;
                }
            }
        }

        #endregion

        #region Entry List Management

        private void ClearEntryList_Click(object sender, RoutedEventArgs e)
        {
            entryList.Clear();
            LogOutput("Entry list cleared.");
        }

        private void AddSampleData_Click(object sender, RoutedEventArgs e)
        {
            AddSampleData();
        }

        private void AddSampleData()
        {
            entryList.Clear();

            // Williams Renault
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "williams",
                Driver1Id = "hill_damon",
                Driver2Id = "villeneuve_jacques"
            });

            // Ferrari
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "ferrari",
                Driver1Id = "schumacher_michael",
                Driver2Id = "irvine_eddie"
            });

            // Benetton Renault
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "benetton",
                Driver1Id = "alesi_jean",
                Driver2Id = "berger_gerhard"
            });

            // McLaren Mercedes
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "mclaren",
                Driver1Id = "hakkinen_mika",
                Driver2Id = "coulthard_david"
            });

            // Jordan Peugeot
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "jordan",
                Driver1Id = "barrichello_rubens",
                Driver2Id = "brundle_martin"
            });

            // Ligier Mugen-Honda
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "ligier_prost",
                Driver1Id = "panis_olivier",
                Driver2Id = "diniz_pedro"
            });

            // Sauber Ford
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "sauber",
                Driver1Id = "frenzen_heinz_harald",
                Driver2Id = "herbert_johnny"
            });

            // Tyrrell Yamaha
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "tyrrell",
                Driver1Id = "salo_mika",
                Driver2Id = "katayama_ukyo"
            });

            // Minardi Ford
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "minardi",
                Driver1Id = "lamy_pedro",
                Driver2Id = "fisichella_giancarlo"
            });

            // Footwork Hart
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "arrows",
                Driver1Id = "verstappen_jos",
                Driver2Id = "rosset_ricardo"
            });

            // Forti Ford
            entryList.Add(new RaceEntryViewModel
            {
                TeamId = "forti",
                Driver1Id = "montermini_andrea",
                Driver2Id = "badoer_luca"
            });

            LogOutput("1996 F1 grid added (11 teams, 22 drivers).");
        }

        #endregion

        #region Generate Files

        private void GenerateFiles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }

                LogOutput("=".PadRight(60, '='));
                LogOutput($"Starting generation... Race ID: {txtRaceId.Text}");
                LogOutput($"Teams: {entryList.Count}");
                LogOutput("");

                if (!int.TryParse(txtRaceId.Text, out int raceId))
                {
                    LogOutput("ERROR: Invalid race ID.");
                    return;
                }

                var entries = entryList.Select(e => new EntryListEntry
                {
                    TeamId = e.TeamId,
                    Driver1Id = e.Driver1Id,
                    Driver2Id = e.Driver2Id
                }).ToList();

                LogOutput("Initializing service...");
                var service = new LiveryService(
                    txtDriversJson.Text,
                    txtSeasonJson.Text,
                    ddsComposer
                );

                // Create PlayerData if player info is provided
                PlayerData playerData = null;
                if (!string.IsNullOrWhiteSpace(txtPlayerName.Text) &&
                    !string.IsNullOrWhiteSpace(txtPlayerHelmet.Text))
                {
                    playerData = new PlayerData
                    {
                        DriverId = "player",
                        Name = txtPlayerName.Text,
                        Nationality = txtPlayerCountry.Text,
                        BaseHelmetFile = txtPlayerHelmet.Text,
                        BaseVisorFile = txtPlayerVisor.Text
                    };
                    LogOutput($"Player: {playerData.Name} ({playerData.Nationality})");
                }

                LogOutput("Generating files...");
                LogOutput($"Drivers Dir: {txtDriversDir.Text}");
                LogOutput($"Season Dir: {txtSeasonDir.Text}");
                LogOutput($"AMS2 Root: {txtAms2Root.Text}");

                service.GenerateRaceFiles(
                    raceId: raceId,
                    raceEntryList: entries,
                    driversDirectory: txtDriversDir.Text,
                    seasonDirectory: txtSeasonDir.Text,
                    ams2RootDirectory: txtAms2Root.Text,
                    playerData: playerData
                );

                LogOutput("");
                LogOutput("✓ Generation complete!");
                LogOutput($"Custom AI: UserData/CustomAIDrivers/");
                LogOutput($"Liveries: Vehicles/Textures/CustomLiveries/Overrides/");
                LogOutput("=".PadRight(60, '='));

                MessageBox.Show(
                    $"Files generated successfully!\n\nAMS2 Root: {txtAms2Root.Text}",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                LogOutput("");
                LogOutput("❌ ERROR: " + ex.Message);
                LogOutput(ex.StackTrace);

                MessageBox.Show(
                    $"Error generating files:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (!File.Exists(txtDriversJson.Text))
            {
                MessageBox.Show("Drivers JSON file not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!File.Exists(txtSeasonJson.Text))
            {
                MessageBox.Show("Season JSON file not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Directory.Exists(txtDriversDir.Text))
            {
                MessageBox.Show("Drivers directory not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Directory.Exists(txtSeasonDir.Text))
            {
                MessageBox.Show("Season directory not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Directory.Exists(txtAms2Root.Text))
            {
                MessageBox.Show("AMS2 root directory not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (entryList.Count == 0)
            {
                MessageBox.Show("Entry list is empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region Output Management

        private void ClearOutput_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();
        }

        private void OpenOutputFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Directory.Exists(txtAms2Root.Text))
                {
                    Process.Start("explorer.exe", txtAms2Root.Text);
                }
                else
                {
                    MessageBox.Show("AMS2 root directory does not exist.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening folder: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogOutput(string message)
        {
            txtOutput.AppendText(message + Environment.NewLine);
            txtOutput.ScrollToEnd();
        }

        #endregion
    }

    #region View Model

    public class RaceEntryViewModel
    {
        public string TeamId { get; set; }
        public string Driver1Id { get; set; }
        public string Driver2Id { get; set; }
    }

    #endregion
}