using AMS2ChEd.Models;
using AMS2ChEd.Models.Enums;
using AMS2ChEd.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AMS2ChEd
{
    public class ReputationItem
    {
        public DriverReputation Reputation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<ReputationItem> reputationList;

        public MainWindow()
        {
            InitializeComponent();
            InitializeReputations();
            LoadSeasons();
        }

        private void InitializeReputations()
        {
            reputationList = new List<ReputationItem>
            {
                new ReputationItem { Reputation = DriverReputation.PAY_DRIVER_WILD_CARD, Name = "Pay Driver - Wild Card", Description = "You are a pay driver, but without enough budget for the whole season. You will substitute existing drivers when they cannot participate in a race. This will be your opportunity to show your talent and hopefully get a full-time seat for the next season." },
                new ReputationItem { Reputation = DriverReputation.PAY_DRIVER_SEASON, Name = "Pay Driver - Full Season", Description = "You are a pay driver with enough budget to cover the season. You can race in F1 but can't be too picky about which team you join. Prove your talent to gain a drive for better teams." },
                new ReputationItem { Reputation = DriverReputation.YOUNG_TALENT, Name = "Young Talent", Description = "You're a potential young star, but still a rough diamond. Teams hiring you are betting on your raw talent, taking into account you might make some mistakes. Bigger teams are still not ready to bet on you." },
                new ReputationItem { Reputation = DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN, Name = "Young Unproven Championship Level Driver", Description = "You've demonstrated that in the right car, you can get wins, but you've not been proven a champion yet." },
                new ReputationItem { Reputation = DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL, Name = "Young Championship Level Driver", Description = "You are an accomplished young driver, able to fight for a championship." },
                new ReputationItem { Reputation = DriverReputation.PRIME_MIDFIELD, Name = "Midfield Driver", Description = "You're a reliable midfield driver, able to consistently bring the car to the finish line, but without showing any great flashes." },
                new ReputationItem { Reputation = DriverReputation.PRIME_STRONG_MIDFIELD, Name = "High Midfield Driver", Description = "You are a solid midfield driver, able to fight consistently for points and podiums in the right situation. You might also be able to fight for a spot in a top team (if they're really in need)." },
                new ReputationItem { Reputation = DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN, Name = "Unproven Championship Level Driver", Description = "You've demonstrated you're able to fight for wins consistently, but you're not in the fight for championship yet." },
                new ReputationItem { Reputation = DriverReputation.PRIME_CHAMPIONSHIP_LEVEL, Name = "Championship Level Driver", Description = "You are an accomplished champion that consistently fights for championships." },
                new ReputationItem { Reputation = DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED, Name = "Washed Championship Level Driver", Description = "You are a former champion that has fallen a bit, but you're eager to be back for a title fight." },
                new ReputationItem { Reputation = DriverReputation.AGEING_MIDFIELD, Name = "Veteran Midfield Driver", Description = "For a midfield team, you're a safe bet. An experienced driver that can bring solid results." },
                new ReputationItem { Reputation = DriverReputation.AGEING_STRONG_MIDFIELD, Name = "Veteran High Midfield Driver", Description = "You are a solid and reliable veteran driver that can fight consistently for points." },
                new ReputationItem { Reputation = DriverReputation.AGEING_CHAMPIONSHIP_LEVEL, Name = "Veteran Championship Level Driver", Description = "You are an experienced driver that can still fight for the title." },
                new ReputationItem { Reputation = DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED, Name = "Washed Veteran Championship Level Driver", Description = "You are a former champion that has fallen from grace, but you're still hungry for success." }
            };

            UpdateReputationComboBox();
        }

        private void UpdateReputationComboBox()
        {
            ReputationComboBox.Items.Clear();
            ReputationDescriptionText.Text = "";

            // Get available reputations based on age
            IEnumerable<DriverReputation> availableReputations;
            if (int.TryParse(DriverAgeTextBox.Text, out int age) && age > 0)
            {
                availableReputations = ReputationUpdater.AvailableReputationForAge(age);
            }
            else
            {
                // If no valid age, show all reputations
                availableReputations = reputationList.Select(r => r.Reputation);
            }

            // Filter and add items
            var filteredReputations = reputationList.Where(r => availableReputations.Contains(r.Reputation)).ToList();

            foreach (var item in filteredReputations)
            {
                ReputationComboBox.Items.Add(new ComboBoxItem { Content = item.Name, Tag = item });
            }

            if (ReputationComboBox.Items.Count > 0)
            {
                ReputationComboBox.SelectedIndex = 0;
            }
        }

        private void LoadSeasons()
        {
            try
            {
                var seasonFolders = SeasonLoader.GetAvailableSeasons();

                if (seasonFolders.Count > 0)
                {
                    foreach (var season in seasonFolders)
                    {
                        SeasonComboBox.Items.Add(new ComboBoxItem { Content = season });
                    }
                    SeasonComboBox.SelectedIndex = 0;
                }
                else
                {
                    SeasonComboBox.Items.Add(new ComboBoxItem { Content = "No Seasons Available" });
                    SeasonComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error loading seasons: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                SeasonComboBox.Items.Add(new ComboBoxItem { Content = "Error Loading Seasons" });
                SeasonComboBox.SelectedIndex = 0;
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuPanel.Visibility = Visibility.Collapsed;
            NewGamePanel.Visibility = Visibility.Visible;
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Load Game feature coming soon!", "Load Game",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new OptionsWindow();
            optionsWindow.Owner = this;
            optionsWindow.ShowDialog();
        }

        private void NationalityTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            NationalityTextBox.Text = NationalityTextBox.Text.ToUpper();
        }

        private void ReputationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReputationComboBox.SelectedItem != null)
            {
                var selectedItem = (ComboBoxItem)ReputationComboBox.SelectedItem;
                var reputationItem = (ReputationItem)selectedItem.Tag;
                ReputationDescriptionText.Text = reputationItem.Description;
            }
        }

        private void DriverAgeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DriverAgeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateReputationComboBox();
        }

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            string driverName = DriverNameTextBox.Text.Trim();
            string nationality = NationalityTextBox.Text.Trim();
            string driverAge = DriverAgeTextBox.Text.Trim();

            if (string.IsNullOrEmpty(driverName) || string.IsNullOrEmpty(nationality) || string.IsNullOrEmpty(driverAge))
            {
                System.Windows.MessageBox.Show("Please fill in all required fields!", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string season = ((ComboBoxItem)SeasonComboBox.SelectedItem).Content.ToString();
            var selectedReputation = (ComboBoxItem)ReputationComboBox.SelectedItem;
            var reputationItem = (ReputationItem)selectedReputation.Tag;

            // Open Team Selection window
            var teamSelectionWindow = new TeamSelectionWindow(season);
            teamSelectionWindow.Owner = this;

            bool teamSelected = false;
            while (!teamSelected)
            {
                if (teamSelectionWindow.ShowDialog() == true)
                {
                    var selectedDriver = teamSelectionWindow.SelectedDriver;
                    var selectedTeamName = teamSelectionWindow.SelectedTeamName;
                    var selectedTeamPrincipal = teamSelectionWindow.SelectedTeamPrincipal;

                    // Get replaced driver's reputation
                    var replacedDriverData = DriversLoader.GetDriver(selectedDriver.DriverId);
                    var seasonData = SeasonLoader.LoadSeason(season);
                    var replacedDriverReputation = GetDriverReputationForSeason(replacedDriverData, season);

                    // Open Contract Letter window
                    var contractLetterWindow = new ContractLetterWindow(
                        selectedTeamName,
                        teamSelectionWindow.SelectedTeamId,
                        selectedTeamPrincipal,
                        driverName,
                        nationality,
                        $"player_{driverName.ToLower().Replace(" ", "_")}",
                        reputationItem.Reputation,
                        selectedDriver.Name,
                        selectedDriver.DriverId,
                        replacedDriverReputation,
                        seasonData
                    );
                    contractLetterWindow.Owner = this;

                    if (contractLetterWindow.ShowDialog() == true)
                    {
                        // Player was hired - proceed
                        teamSelected = true;

                        string message = $"Game Created!\n\n" +
                                       $"Driver: {driverName}\n" +
                                       $"Nationality: {nationality}\n" +
                                       $"Age: {driverAge}\n" +
                                       $"Season: {season}\n" +
                                       $"Reputation: {reputationItem.Name}\n" +
                                       $"Team: {selectedTeamName}\n" +
                                       $"Replacing: {selectedDriver.Name} (#{selectedDriver.Number})";

                        System.Windows.MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        // Player was rejected - create new team selection window for retry
                        teamSelectionWindow = new TeamSelectionWindow(season);
                        teamSelectionWindow.Owner = this;
                    }
                }
                else
                {
                    // User cancelled team selection
                    break;
                }
            }
        }

        private DriverReputation GetDriverReputationForSeason(DriverData driverData, string season)
        {
            if (driverData?.Ratings != null)
            {
                var seasonRating = driverData.Ratings.FirstOrDefault(r => r.Season == season);
                if (seasonRating != null)
                {
                    return seasonRating.Reputation;
                }

                // If exact season not found, use the first available rating
                if (driverData.Ratings.Count > 0)
                {
                    return driverData.Ratings[0].Reputation;
                }
            }

            // Default fallback
            return DriverReputation.PRIME_MIDFIELD;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuPanel.Visibility = Visibility.Visible;
            NewGamePanel.Visibility = Visibility.Collapsed;

            // Clear fields
            DriverNameTextBox.Clear();
            NationalityTextBox.Clear();
            DriverAgeTextBox.Clear();
            SeasonComboBox.SelectedIndex = 0;
            ReputationComboBox.SelectedIndex = 0;
        }
    }
}