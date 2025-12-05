using AMS2ChEd.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using MessageBox = System.Windows.MessageBox;

namespace AMS2ChEd.Views
{
    public class StandingEntry
    {
        public int Position { get; set; }
        public int Number { get; set; }
        public string DriverName { get; set; }
        public string TeamName { get; set; }
        public string BestLap { get; set; }
        public Brush LapTimeColor { get; set; }
    }

    public partial class RaceWeekendWindow : Window
    {
        private SaveGame saveGame;

        public RaceWeekendWindow(SaveGame saveGame)
        {
            InitializeComponent();
            this.saveGame = saveGame;
            LoadRaceWeekend();
        }

        private void LoadRaceWeekend()
        {
            // Set Grand Prix info
            if (saveGame.NextGpIndex < saveGame.CurrentSeason.Races.Count)
            {
                var nextRace = saveGame.CurrentSeason.Races[saveGame.NextGpIndex];
                GrandPrixHeader.Text = $"{nextRace.RaceName.ToUpper()} {saveGame.CurrentSeason.Year}";
                CircuitHeader.Text = nextRace.Circuit?.ToUpper() ?? "CIRCUIT";
            }

            SessionText.Text = "PRACTICE 1";

            // Load mocked standings
            var standings = new List<StandingEntry>
            {
                new StandingEntry { Position = 1, Number = 16, DriverName = "CHARLES LECLERC", TeamName = "FERRARI", BestLap = "1:12.345", LapTimeColor = new SolidColorBrush(Color.FromRgb(255, 255, 0)) },
                new StandingEntry { Position = 2, Number = 1, DriverName = "MAX VERSTAPPEN", TeamName = "RED BULL RACING", BestLap = "1:12.456", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 3, Number = 55, DriverName = "CARLOS SAINZ", TeamName = "FERRARI", BestLap = "1:12.567", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 4, Number = 44, DriverName = "LEWIS HAMILTON", TeamName = "MERCEDES", BestLap = "1:12.678", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 5, Number = 63, DriverName = "GEORGE RUSSELL", TeamName = "MERCEDES", BestLap = "1:12.789", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 6, Number = 11, DriverName = "SERGIO PEREZ", TeamName = "RED BULL RACING", BestLap = "1:12.890", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 7, Number = 4, DriverName = "LANDO NORRIS", TeamName = "MCLAREN", BestLap = "1:12.901", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 8, Number = 81, DriverName = "OSCAR PIASTRI", TeamName = "MCLAREN", BestLap = "1:13.012", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 9, Number = 14, DriverName = "FERNANDO ALONSO", TeamName = "ASTON MARTIN", BestLap = "1:13.123", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 10, Number = 18, DriverName = "LANCE STROLL", TeamName = "ASTON MARTIN", BestLap = "1:13.234", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 11, Number = 10, DriverName = "PIERRE GASLY", TeamName = "ALPINE", BestLap = "1:13.345", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 12, Number = 31, DriverName = "ESTEBAN OCON", TeamName = "ALPINE", BestLap = "1:13.456", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 13, Number = 23, DriverName = "ALEX ALBON", TeamName = "WILLIAMS", BestLap = "1:13.567", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 14, Number = 2, DriverName = "LOGAN SARGEANT", TeamName = "WILLIAMS", BestLap = "1:13.678", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 15, Number = 77, DriverName = "VALTTERI BOTTAS", TeamName = "ALFA ROMEO", BestLap = "1:13.789", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 16, Number = 24, DriverName = "ZHOU GUANYU", TeamName = "ALFA ROMEO", BestLap = "1:13.890", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 17, Number = 20, DriverName = "KEVIN MAGNUSSEN", TeamName = "HAAS F1 TEAM", BestLap = "1:13.901", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 18, Number = 27, DriverName = "NICO HULKENBERG", TeamName = "HAAS F1 TEAM", BestLap = "1:14.012", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 19, Number = 22, DriverName = "YUKI TSUNODA", TeamName = "ALPHATAURI", BestLap = "1:14.123", LapTimeColor = Brushes.White },
                new StandingEntry { Position = 20, Number = 21, DriverName = "NYCK DE VRIES", TeamName = "ALPHATAURI", BestLap = "1:14.234", LapTimeColor = Brushes.White }
            };

            StandingsItems.ItemsSource = standings;
        }

        private void NextSession_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Session progression coming soon!", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}