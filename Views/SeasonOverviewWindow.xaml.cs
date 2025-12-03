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
                // Generate entry list for next GP (with absence handling)
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
            var driversCache = saveGame.Drivers.ToDictionary(d => d.DriverId, d => d);

            // Create base entry list from teams
            foreach (var team in saveGame.CurrentSeason.Teams)
            {
                var driver1Reputation = GetDriverReputation(team.Driver1Contract.DriverId, saveGame.CurrentSeason.Year.ToString());
                var driver2Reputation = GetDriverReputation(team.Driver2Contract.DriverId, saveGame.CurrentSeason.Year.ToString());

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

            // Process absences for the next GP
            if (saveGame.CurrentSeason.Absences != null && saveGame.CurrentSeason.Absences.Any())
            {
                var nextGpId = saveGame.CurrentSeason.Races[saveGame.NextGpIndex].RaceId;
                var nextGpAbsences = saveGame.CurrentSeason.Absences
                    .Where(a => a.RaceId == nextGpId)
                    .ToList();

                ProcessAbsences(entryList, nextGpAbsences);
            }

            return entryList;
        }

        private void ProcessAbsences(List<EntryListEntry> entryList, List<Absence> absences)
        {
            int i = 0;
            var currentAbsence = absences[i];
            Absence chainedAbsence = null;
            var playerHasSteppedIn = false;

            while (i < absences.Count)
            {
                currentAbsence = chainedAbsence ?? absences[i];

                // Check if player can apply for this absence
                bool playerCanApply = !playerHasSteppedIn && (currentAbsence.DriverOut != saveGame.PlayerData.DriverId);

                if (playerCanApply)
                {
                    // Ask player if they want to apply
                    var result = System.Windows.MessageBox.Show(
                        $"Driver {GetDriverName(currentAbsence.DriverOut)} from team {GetTeamName(currentAbsence.TeamId)} is unable to participate in this race.\n\n" +
                        $"Would you like to apply for this position?",
                        "Substitution Opportunity",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Get player's current team reputation
                        var playerTeam = saveGame.CurrentSeason.Teams.FirstOrDefault(t => t.TeamId == saveGame.PlayerData.TeamId);
                        var proposedTeam = saveGame.CurrentSeason.Teams.FirstOrDefault(t => t.TeamId == currentAbsence.TeamId);
                        var proposedDriverReputation = GetDriverReputation(currentAbsence.DriverIn, saveGame.CurrentSeason.Year.ToString());
                        var playerReputation = GetDriverReputation(saveGame.PlayerData.DriverId, saveGame.CurrentSeason.Year.ToString());

                        if (playerTeam != null && proposedTeam != null && playerTeam.Reputation >= proposedTeam.Reputation)
                        {
                            // Player's team won't let them go
                            System.Windows.MessageBox.Show(
                                $"Your team ({GetTeamName(playerTeam.TeamId)}) won't let you go for this substitution.",
                                "Request Denied",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                            ExecuteDeclaredAbsence(entryList, currentAbsence);

                            if (currentAbsence.ChainedAbsence != null)
                            {
                                chainedAbsence = currentAbsence.ChainedAbsence;
                                continue;
                            }
                            else
                            {
                                i++;
                                continue;
                            }
                        }
                        else if (proposedTeam != null && proposedTeam.Reputation > TeamReputation.MINNOW &&
                                 playerReputation <= proposedDriverReputation)
                        {
                            // Team prefers the proposed driver
                            System.Windows.MessageBox.Show(
                                $"Sorry, {GetTeamName(currentAbsence.TeamId)} prefers {GetDriverName(currentAbsence.DriverIn)} for this position.",
                                "Application Rejected",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                            ExecuteDeclaredAbsence(entryList, currentAbsence);

                            if (currentAbsence.ChainedAbsence != null)
                            {
                                chainedAbsence = currentAbsence.ChainedAbsence;
                                continue;
                            }
                            else
                            {
                                i++;
                                continue;
                            }
                        }
                        else
                        {
                            // create new absence
                            if (saveGame.PlayerData.TeamId != null)
                            {
                                // Get list of employed drivers
                                var employedDriverIds = entryList
                                    .SelectMany(e => new[] { e.Driver1Id, e.Driver2Id })
                                    .Distinct()
                                    .ToHashSet();

                                // Find first unemployed driver with reputation <= player's reputation
                                var substituteDriver = saveGame.Drivers
                                    .Where(d => !employedDriverIds.Contains(d.DriverId) && d.DriverId != saveGame.PlayerData.DriverId)
                                    .Select(d => new
                                    {
                                        DriverId = d.DriverId,
                                        Reputation = GetDriverReputation(d.DriverId, saveGame.CurrentSeason.Year.ToString())
                                    })
                                    .Where(d => d.Reputation <= playerReputation)
                                    .OrderByDescending(d => d.Reputation) // Get the best available driver
                                    .FirstOrDefault();

                                currentAbsence.ChainedAbsence = new Absence
                                {
                                    DriverOut = saveGame.PlayerData.DriverId,
                                    RaceId = currentAbsence.RaceId,
                                    TeamId = saveGame.PlayerData.TeamId,
                                    DriverIn = substituteDriver?.DriverId ?? "", // Use the substitute driver or empty string if none found
                                    NewDriverNumber = entryList
                                                        .Where(e => e.Driver1Id == saveGame.PlayerData.DriverId || e.Driver2Id == saveGame.PlayerData.DriverId)
                                                        .Select(e => e.Driver1Id == saveGame.PlayerData.DriverId ? e.Driver1Number : e.Driver2Number)
                                                        .First(),

                                };
                            }

                            // Player successfully steps in
                            StepInAbsence(entryList, currentAbsence);
                            playerHasSteppedIn = true;

                            System.Windows.MessageBox.Show(
                                $"Congratulations! You will substitute for {GetDriverName(currentAbsence.DriverOut)} at {GetTeamName(currentAbsence.TeamId)} for this race!",
                                "Application Accepted",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                            chainedAbsence = currentAbsence.ChainedAbsence;
                            continue;
                        }
                    }
                    else
                    {
                        // Player declined
                        ExecuteDeclaredAbsence(entryList, currentAbsence);
                        chainedAbsence = currentAbsence.ChainedAbsence;

                        if (currentAbsence.ChainedAbsence == null)
                        {
                            i++;
                            continue;
                        }
                    }
                }
                else
                {
                    // No player interaction needed, just execute the absence
                    ExecuteDeclaredAbsence(entryList, currentAbsence);
                    chainedAbsence = currentAbsence.ChainedAbsence;

                    if (currentAbsence.ChainedAbsence == null)
                    {
                        i++;
                        continue;
                    }
                }
            }
        }

        private void ExecuteDeclaredAbsence(List<EntryListEntry> entryList, Absence absence)
        {
            // Find the team entry
            var teamEntry = entryList.FirstOrDefault(e => e.TeamId == absence.TeamId);
            if (teamEntry == null) return;

            var driverInReputation = GetDriverReputation(absence.DriverIn, saveGame.CurrentSeason.Year.ToString());

            // Replace the driver who is out with the declared substitute
            if (teamEntry.Driver1Id == absence.DriverOut)
            {
                teamEntry.Driver1Id = absence.DriverIn;
                teamEntry.Driver1Reputation = driverInReputation;
                teamEntry.Driver1Number = absence.NewDriverNumber;
            }
            else if (teamEntry.Driver2Id == absence.DriverOut)
            {
                teamEntry.Driver2Id = absence.DriverIn;
                teamEntry.Driver2Reputation = driverInReputation;
                teamEntry.Driver2Number = absence.NewDriverNumber;
            }
        }

        private void StepInAbsence(List<EntryListEntry> entryList, Absence absence)
        {
            // Find the team entry where the absence occurs
            var teamEntry = entryList.FirstOrDefault(e => e.TeamId == absence.TeamId);
            if (teamEntry == null) return;

            var playerReputation = GetDriverReputation(saveGame.PlayerData.DriverId, saveGame.CurrentSeason.Year.ToString());

            // Replace the driver who is out with the player
            if (teamEntry.Driver1Id == absence.DriverOut)
            {
                teamEntry.Driver1Id = saveGame.PlayerData.DriverId;
                teamEntry.Driver1Reputation = playerReputation;
                teamEntry.Driver1Number = absence.NewDriverNumber;
            }
            else if (teamEntry.Driver2Id == absence.DriverOut)
            {
                teamEntry.Driver2Id = saveGame.PlayerData.DriverId;
                teamEntry.Driver2Reputation = playerReputation;
                teamEntry.Driver2Number = absence.NewDriverNumber;
            }
        }

        private string GetDriverName(string driverId)
        {
            if (driverId == saveGame.PlayerData.DriverId)
                return saveGame.PlayerData.Name;

            var driver = saveGame.Drivers.FirstOrDefault(d => d.DriverId == driverId);
            return driver?.Name ?? "Unknown Driver";
        }

        private string GetTeamName(string teamId)
        {
            var teamsCache = TeamsLoader.LoadTeams();
            var teamEntry = saveGame.CurrentSeason.Teams.FirstOrDefault(t => t.TeamId == teamId);
            var team = teamsCache.ContainsKey(teamId) ? teamsCache[teamId] : null;

            return team?.TeamName ?? teamEntry?.TeamName ?? "Unknown Team";
        }

        private DriverReputation GetDriverReputation(string driverId, string season)
        {
            var driversCache = saveGame.Drivers.ToDictionary(d => d.DriverId, d => d);

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