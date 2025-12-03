using AMS2ChEd.Models;
using AMS2ChEd.Models.Enums;
using AMS2ChEd.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace AMS2ChEd
{
    public class DriverStandingDisplay
    {
        public int Position { get; set; }
        public string DriverName { get; set; }
        public double Points { get; set; }
        public bool IsPlayer { get; set; }
    }

    public class ConstructorStandingDisplay
    {
        public int Position { get; set; }
        public string TeamName { get; set; }
        public double Points { get; set; }
        public bool IsPlayerTeam { get; set; }
    }

    public partial class SeasonOverviewWindow : Window
    {
        private SaveGame saveGame;

        public SeasonOverviewWindow(SaveGame saveGame)
        {
            InitializeComponent();
            this.saveGame = saveGame;
            LoadOverview();
        }

        private void LoadOverview()
        {
            // Set season and next GP
            SeasonText.Text = $"Season: {saveGame.CurrentSeason.Year}";

            if (saveGame.NextGpIndex < saveGame.CurrentSeason.Races.Count)
            {
                var nextRace = saveGame.CurrentSeason.Races[saveGame.NextGpIndex];
                NextGPText.Text = nextRace.RaceName.ToUpper();
            }
            else
            {
                NextGPText.Text = "SEASON COMPLETE";
            }

            // Load driver standings
            LoadDriverStandings();

            // Load constructor standings
            LoadConstructorStandings();
        }

        private void LoadDriverStandings()
        {
            var displayList = new List<DriverStandingDisplay>();

            // Load from save game standings using the Drivers list
            foreach (var standing in saveGame.CurrentDriverStandings.OrderBy(s => s.Position))
            {
                var driver = saveGame.Drivers.FirstOrDefault(d => d.DriverId == standing.DriverId);
                string driverName = driver?.Name ?? "Unknown Driver";

                displayList.Add(new DriverStandingDisplay
                {
                    Position = standing.Position,
                    DriverName = driverName,
                    Points = standing.Points,
                    IsPlayer = standing.DriverId == saveGame.PlayerData.DriverId
                });
            }

            DriverStandingsItems.ItemsSource = displayList;
        }

        private void LoadConstructorStandings()
        {
            var teamsCache = TeamsLoader.LoadTeams();
            var displayList = new List<ConstructorStandingDisplay>();

            // Load from save game standings
            foreach (var standing in saveGame.CurrentConstructorStandings.OrderBy(s => s.Position))
            {
                var teamEntry = saveGame.CurrentSeason.Teams.FirstOrDefault(t => t.TeamId == standing.TeamId);
                var team = teamsCache.ContainsKey(standing.TeamId)
                    ? teamsCache[standing.TeamId]
                    : null;

                displayList.Add(new ConstructorStandingDisplay
                {
                    Position = standing.Position,
                    TeamName = team?.TeamName ?? teamEntry?.TeamName ?? "Unknown Team",
                    Points = standing.Points,
                    IsPlayerTeam = standing.TeamId == saveGame.PlayerData.TeamId
                });
            }

            ConstructorStandingsItems.ItemsSource = displayList;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Generate entry list for next GP
                saveGame.NextGpEntryList = GenerateEntryList();

                // Save the updated game state
                string saveName = $"{saveGame.PlayerData.Name}_{saveGame.CurrentSeason.Year}".Replace(" ", "_");
                SaveGameService.SaveGame(saveGame, saveName);

                // TODO: Navigate to GP weekend
                System.Windows.MessageBox.Show("GP Weekend screen coming soon!", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error preparing GP: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<EntryListEntry> GenerateEntryList()
        {
            var entryList = new List<EntryListEntry>();
            var driversCache = DriversLoader.LoadDrivers();

            foreach (var team in saveGame.CurrentSeason.Teams)
            {
                // Get driver 1 reputation
                var driver1Reputation = DriverReputation.PRIME_MIDFIELD; // Default
                if (team.Driver1Contract.DriverId == saveGame.PlayerData.DriverId)
                {
                    // Player - use saved reputation from initial selection
                    // We need to find it from the standings or use a default
                    var playerStanding = saveGame.CurrentDriverStandings.FirstOrDefault(s => s.DriverId == saveGame.PlayerData.DriverId);
                    // For now, we'll need to get this from somewhere - let's use a helper method
                    driver1Reputation = GetDriverReputation(team.Driver1Contract.DriverId, saveGame.CurrentSeason.Year.ToString());
                }
                else if (driversCache.ContainsKey(team.Driver1Contract.DriverId))
                {
                    driver1Reputation = GetDriverReputation(team.Driver1Contract.DriverId, saveGame.CurrentSeason.Year.ToString());
                }

                // Get driver 2 reputation
                var driver2Reputation = DriverReputation.PRIME_MIDFIELD; // Default
                if (team.Driver2Contract.DriverId == saveGame.PlayerData.DriverId)
                {
                    driver2Reputation = GetDriverReputation(team.Driver2Contract.DriverId, saveGame.CurrentSeason.Year.ToString());
                }
                else if (driversCache.ContainsKey(team.Driver2Contract.DriverId))
                {
                    driver2Reputation = GetDriverReputation(team.Driver2Contract.DriverId, saveGame.CurrentSeason.Year.ToString());
                }

                entryList.Add(new EntryListEntry
                {
                    TeamId = team.TeamId,
                    Driver1Id = team.Driver1Contract.DriverId,
                    Driver1Reputation = driver1Reputation,
                    Driver1Number = team.Driver1Contract.DriverNumber,
                    Driver2Id = team.Driver2Contract.DriverId,
                    Driver2Reputation = driver2Reputation,
                    Driver2Number = team.Driver2Contract.DriverNumber
                });
            }

            return entryList;
        }

        private DriverReputation GetDriverReputation(string driverId, string season)
        {
            var driversCache = DriversLoader.LoadDrivers();

            if (driversCache.ContainsKey(driverId))
            {
                var driverData = driversCache[driverId];
                var seasonRating = driverData.Ratings?.FirstOrDefault(r => r.Season == season);
                if (seasonRating != null)
                {
                    return seasonRating.Reputation;
                }

                // If no exact season match, use first available
                if (driverData.Ratings != null && driverData.Ratings.Count > 0)
                {
                    return driverData.Ratings[0].Reputation;
                }
            }

            // Default fallback
            return DriverReputation.PRIME_MIDFIELD;
        }
    }
}