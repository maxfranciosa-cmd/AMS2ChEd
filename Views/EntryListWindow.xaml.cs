using AMS2ChEd.Models;
using AMS2ChEd.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace AMS2ChEd.Views
{
    // Converter to make player name bold
    public class BoolToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? FontWeights.Bold : FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EntryDisplay
    {
        public int DriverNumber { get; set; }
        public string DriverName { get; set; }
        public string Nationality { get; set; }
        public string TeamName { get; set; }
        public bool IsPlayer { get; set; }
    }

    public partial class EntryListWindow : Window
    {
        private SaveGame saveGame;

        public EntryListWindow(SaveGame saveGame)
        {
            InitializeComponent();
            this.saveGame = saveGame;
            LoadEntryList();
        }

        private void LoadEntryList()
        {
            // Set Grand Prix name
            if (saveGame.NextGpIndex < saveGame.CurrentSeason.Races.Count)
            {
                var nextRace = saveGame.CurrentSeason.Races[saveGame.NextGpIndex];
                GrandPrixText.Text = nextRace.RaceName.ToUpper();
            }

            // Set date
            DateText.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

            // Set footer
            FooterText.Text = $"This document is the official entry list for the {saveGame.CurrentSeason.Year} season.";

            // Build entry display list
            var displayList = new List<EntryDisplay>();

            if (saveGame.NextGpEntryList != null && saveGame.NextGpEntryList.Any())
            {
                // Sort by team and driver number
                var sortedEntries = saveGame.NextGpEntryList
                    .OrderBy(e => GetTeamName(e.TeamId))
                    .ToList();

                foreach (var entry in sortedEntries)
                {
                    var teamName = GetTeamName(entry.TeamId);
                    var nameAndNationality1 = GetDriverNameAdNationality(entry.Driver1Id);
                    var nameAndNationality2 = GetDriverNameAdNationality(entry.Driver2Id);
                    // Add Driver 1
                    displayList.Add(new EntryDisplay
                    {
                        DriverNumber = entry.Driver1Number,
                        DriverName = nameAndNationality1[0],
                        Nationality = nameAndNationality1[1],
                        TeamName = teamName,
                        IsPlayer = entry.Driver1Id == saveGame.PlayerData.DriverId
                    });

                    // Add Driver 2
                    displayList.Add(new EntryDisplay
                    {
                        DriverNumber = entry.Driver2Number,
                        DriverName = nameAndNationality2[0],
                        Nationality = nameAndNationality2[1],
                        TeamName = teamName,
                        IsPlayer = entry.Driver2Id == saveGame.PlayerData.DriverId
                    });
                }
            }

            EntryListItems.ItemsSource = displayList;
        }

        private string[] GetDriverNameAdNationality(string driverId)
        {
            if (driverId == saveGame.PlayerData.DriverId)
                return new[] { saveGame.PlayerData.Name.ToUpper(), saveGame.PlayerData.Nationality };

            var driver = saveGame.Drivers.FirstOrDefault(d => d.DriverId == driverId);
            return new[] { driver.Name.ToUpper(), driver.Nationality.ToUpper() };
        }

        private string GetTeamName(string teamId)
        {
            var teamsCache = TeamsLoader.LoadTeams();
            var teamEntry = saveGame.CurrentSeason.Teams.FirstOrDefault(t => t.TeamId == teamId);
            var team = teamsCache.ContainsKey(teamId) ? teamsCache[teamId] : null;

            var teamName = teamEntry?.TeamName ?? team?.TeamName ?? "Unknown Team";
            return teamName.ToUpper();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            var raceWeekendWindow = new RaceWeekendWindow(saveGame);
            raceWeekendWindow.Show();
            this.Close();
        }
    }
}