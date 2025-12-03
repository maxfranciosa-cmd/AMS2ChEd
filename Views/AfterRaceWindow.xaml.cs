using AMS2ChEd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AMS2ChEd.Views
{
    public partial class AfterRaceWindow : Window
    {
        private RaceResult _result;


        public AfterRaceWindow(RaceResult result)
        {
            InitializeComponent();
            _result = result ?? new RaceResult {
                 Classification = null,
                 UpdatedStandings = null
            };
            Populate();
        }


        private void Populate()
        {
            // Example: bind result classification
            ResultsList.ItemsSource = _result.Classification;
            UpdatedStandings.ItemsSource = _result.UpdatedStandings;
        }


        private void SaveReturn_Click(object sender, RoutedEventArgs e)
        {
            // Persist and return to pre-race
            var pre = new PreRaceWindow();
            pre.Owner = this.Owner;
            pre.Show();
            this.Close();
        }


        private void NextRace_Click(object sender, RoutedEventArgs e)
        {
            // Advance calendar and re-open PreRace
            var pre = new PreRaceWindow();
            pre.Owner = this.Owner;
            pre.Show();
            this.Close();
        }
    }
}
