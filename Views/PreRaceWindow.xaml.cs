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
    public partial class PreRaceWindow : Window
    {
        public PreRaceWindow()
        {
            InitializeComponent();


            // TODO: load calendar.json into CalendarList
            CalendarList.Items.Add("Round 1 — Australia (Done)");
            CalendarList.Items.Add("Round 2 — Brazil (Current)");
            CalendarList.Items.Add("Round 3 — Imola");


            StandingsList.Items.Add("1. Ayrton Senna — 20 pts");
            StandingsList.Items.Add("2. Alain Prost — 16 pts");
        }


        private void OpenListening_Click(object sender, RoutedEventArgs e)
        {
            var win = new ListeningWindow();
            win.Owner = this;
            win.Show();
        }


        private void Listen_Click(object sender, RoutedEventArgs e)
        {
            var win = new ListeningWindow();
            win.Owner = this;
            win.Show();
        }
    }
}
