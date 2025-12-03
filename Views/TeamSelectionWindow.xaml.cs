using AMS2ChEd.Models;
using AMS2ChEd.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AMS2ChEd
{
    public class Driver
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Number { get; set; }
        public string DriverId { get; set; }
        public string PhotoUrl { get; set; }
        public bool Replaceable { get; set; }
    }

    public class TeamDisplay
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamPrincipal { get; set; }
        public Driver Driver1 { get; set; }
        public Driver Driver2 { get; set; }
    }

    public partial class TeamSelectionWindow : Window
    {
        private List<TeamDisplay> teams;
        private Driver selectedDriver;
        private Border selectedBorder;

        public Driver SelectedDriver => selectedDriver;
        public string SelectedTeamName { get; private set; }
        public string SelectedTeamId { get; private set; }
        public string SelectedTeamPrincipal { get; private set; }

        public TeamSelectionWindow(string seasonYear)
        {
            InitializeComponent();
            LoadSeason(seasonYear);
        }

        private void LoadSeason(string seasonYear)
        {
            try
            {
                // Load all data using the loaders
                var driversCache = DriversLoader.LoadDrivers();
                var teamsCache = TeamsLoader.LoadTeams();
                var seasonData = SeasonLoader.LoadSeason(seasonYear);

                teams = new List<TeamDisplay>();

                foreach (var teamEntry in seasonData.Teams)
                {
                    // Get team name from TeamEntry
                    string teamName = teamEntry.TeamName;

                    // Get driver 1 data
                    var driver1Id = teamEntry.Driver1Contract.DriverId;
                    if (!driversCache.ContainsKey(driver1Id))
                    {
                        System.Diagnostics.Debug.WriteLine($"Skipping team {teamName}: Driver 1 '{driver1Id}' not found in drivers database");
                        continue;
                    }

                    var driver1Data = driversCache[driver1Id];
                    var driver1 = new Driver
                    {
                        DriverId = driver1Data.DriverId,
                        Name = driver1Data.Name,
                        Nationality = string.IsNullOrEmpty(driver1Data.Nationality) ? "N/A" : driver1Data.Nationality,
                        Number = teamEntry.Driver1Contract.DriverNumber,
                        PhotoUrl = "N/A",
                        Replaceable = teamEntry.Driver1Contract.Replaceable
                    };

                    // Get driver 2 data
                    var driver2Id = teamEntry.Driver2Contract.DriverId;
                    if (!driversCache.ContainsKey(driver2Id))
                    {
                        System.Diagnostics.Debug.WriteLine($"Skipping team {teamName}: Driver 2 '{driver2Id}' not found in drivers database");
                        continue;
                    }

                    var driver2Data = driversCache[driver2Id];
                    var driver2 = new Driver
                    {
                        DriverId = driver2Data.DriverId,
                        Name = driver2Data.Name,
                        Nationality = string.IsNullOrEmpty(driver2Data.Nationality) ? "N/A" : driver2Data.Nationality,
                        Number = teamEntry.Driver2Contract.DriverNumber,
                        PhotoUrl = "N/A",
                        Replaceable = teamEntry.Driver2Contract.Replaceable
                    };

                    teams.Add(new TeamDisplay
                    {
                        TeamId = teamEntry.TeamId,
                        TeamName = teamName,
                        TeamPrincipal = teamEntry.TeamPrincipal,
                        Driver1 = driver1,
                        Driver2 = driver2
                    });
                }

                TeamsItemsControl.ItemsSource = teams;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error loading season data: {ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LoadMockData();
            }
        }

        private void LoadMockData()
        {
            // Fallback mock data
            teams = new List<TeamDisplay>
            {
                new TeamDisplay
                {
                    TeamName = "Red Bull Racing",
                    Driver1 = new Driver { DriverId = "verstappen_max", Name = "Max Verstappen", Nationality = "NED", Number = 1, Replaceable = false },
                    Driver2 = new Driver { DriverId = "perez_sergio", Name = "Sergio Perez", Nationality = "MEX", Number = 11, Replaceable = true }
                }
            };

            TeamsItemsControl.ItemsSource = teams;
        }

        private void DriverCard_Click(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            if (border == null) return;

            var driver = border.Tag as Driver;
            if (driver == null) return;

            // Non-replaceable drivers are already visually disabled, ignore clicks
            if (!driver.Replaceable)
                return;

            // Remove previous selection
            if (selectedBorder != null)
            {
                selectedBorder.BorderBrush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#444444"));
                selectedBorder.BorderThickness = new Thickness(2);
            }

            // Apply new selection
            selectedDriver = driver;
            selectedBorder = border;
            selectedBorder.BorderBrush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#c41e3a"));
            selectedBorder.BorderThickness = new Thickness(3);

            // Find and store the team name for this driver
            var team = teams.FirstOrDefault(t => t.Driver1 == driver || t.Driver2 == driver);
            if (team != null)
            {
                SelectedTeamId = team.TeamId;
                SelectedTeamName = team.TeamName;
                SelectedTeamPrincipal = team.TeamPrincipal;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDriver == null)
            {
                System.Windows.MessageBox.Show("Please select a driver to replace.", "No Driver Selected",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}