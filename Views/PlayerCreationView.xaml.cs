using AMS2ChEd.Models.Enums;
using AMS2ChEd.Services;
using AMS2ChEd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Interaction logic for PlayerCreationView.xaml
    /// </summary>
    /// 

    public class ReputationItem {
        public DriverReputation Reputation { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public partial class PlayerCreationView : Window
    {
        public static ReputationItem[] ReputationItems =
        {
            new() { Reputation = DriverReputation.PAY_DRIVER_WILD_CARD, Name = "Pay Driver - Wild Card", Description = "You are a pay driver, but with no enough budget for the whole season. you will substitute existing drivers when they cannot participate a race. this will be your opportunity to show your talent and hopefully get a full-time seat for the next season" },
            new() { Reputation = DriverReputation.PAY_DRIVER_SEASON, Name = "Pay Driver - Full Season", Description = "You are a pay driver with enough budget to cover for the season. You can race in F1 but can't be too picky on which team you could join. prove your talent to be able to gain a drive for better teams." },

            new() { Reputation = DriverReputation.YOUNG_TALENT, Name = "Young Talent", Description = "You're a potential young star, but still rough diamond. but teams hiring you are betting on your raw talent, taking account you might make some mistakes. Bigger teams are still not ready to bet on you." },
            new() { Reputation = DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN, Name = "Young Unproven Championship Level Driver", Description = "You've demonstrated that in the right car, you can get wins. but you're non been proven a champion yet." },
            new() { Reputation = DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL, Name = "Young Championship Level Driver", Description = "You are an accomplished young driver, able to fight for a championship." },

            new() { Reputation = DriverReputation.PRIME_MIDFIELD, Name = "Midfield Driver", Description = "You're a reliable midfield driver, able to consistently bring the car to the finish line, but without showing any great flashes." },
            new() { Reputation = DriverReputation.PRIME_STRONG_MIDFIELD, Name = "High Midfield Driver", Description = "You are a solid midfield driver, able to fight consistently for points and podiums in the right situation. might also be able to fight for a spot in a top team (if they're really in need)." },
            new() { Reputation = DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN, Name = "Unproven Championship Level Driver", Description = "You've demonstrated to be able to fight for wins consistently, but not in the fight for championship" },
            new() { Reputation = DriverReputation.PRIME_CHAMPIONSHIP_LEVEL, Name = "Championship Level Driver", Description = "You are an accomplished champion that consistently fights for championships." },
            new() { Reputation = DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED, Name = "Washed Championship Level Driver", Description = "You are a former champion that fell a bit, but eager to be back for a title fight." },

            new() { Reputation = DriverReputation.AGEING_MIDFIELD, Name = "Veteran Midfield Driver", Description = "for a midfield team, you're a safe bet. an experienced driver that can bring solid results." },
            new() { Reputation = DriverReputation.AGEING_STRONG_MIDFIELD, Name = "Veteran High Midfield Driver", Description = "You are a solid and reliable veteran driver that can fight consistently for points." },
            new() { Reputation = DriverReputation.AGEING_CHAMPIONSHIP_LEVEL, Name = "Veteran Championship Level Driver", Description = "You are an experienced driver that can still fight for the title." },
            new() { Reputation = DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED, Name = "Washed Veteran Championship Level Driver", Description = "You are a former champion that fell from a grace, but still hungry for success." }
        };
        int _selectedSeason;

        public PlayerCreationView(int selectedSeason)
        {
            InitializeComponent();

            LoadComboBoxItems();

            GameSaveService.MemorySave.CurrentSeason = selectedSeason;

            _selectedSeason = selectedSeason;
        }

        public PlayerCreationView(GameSave save)
        {
            InitializeComponent();
            
            LoadComboBoxItems();

            LoadSave(save);

            _selectedSeason = save.CurrentSeason;
        }

        public void LoadComboBoxItems(int age = 0)
        {
            if (age == 0)
                cbReputation.ItemsSource = ReputationItems;
            else
            {
                var reputationsForAge = ReputationUpdater.AvailableReputationForAge(age);
                cbReputation.ItemsSource = ReputationItems.Where(i => reputationsForAge.Contains(i.Reputation));
            }
        }

        private void LoadSave(GameSave save)
        {
            txtAge.Text = save.PlayerDriverInfo.Age.ToString(); ;
            txtName.Text = save.PlayerDriverInfo.Name;
            txtNationality.Text = save.PlayerDriverInfo.Nationality;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameSaveService.MemorySave.PlayerDriverInfo = new()
            {
                Age = int.Parse(txtAge.Text),
                Name = txtName.Text,
                Nationality = txtNationality.Text,
                Reputation = ((ReputationItem)cbReputation.SelectedItem).Reputation
            };

            var playerCreationWindow = new TeamSelectionView();
            playerCreationWindow.Owner = this.Owner;
            playerCreationWindow.Activate();
            this.Close();
        }

        private void txtAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !((new Regex("^[0-9]+$")).IsMatch(e.Text));



        }

        private void cbReputation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbReputationDescription.Text = ((ReputationItem)e.AddedItems[0]).Description;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Owner = this.Owner;
            mainWindow.Activate();
            this.Close();
        }
    }
}
