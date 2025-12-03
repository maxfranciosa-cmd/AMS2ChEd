using AMS2ChEd.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AMS2ChEd.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        public ObservableCollection<int> AvailableSeasons { get; set; }

        private int _selectedSeason = 1996;
        public int SelectedSeason
        {
            get => _selectedSeason;
            set => _selectedSeason = value;
        }

        public MainViewModel() {

            AvailableSeasons = LoadSeasons();
        }

        private ObservableCollection<int>? LoadSeasons()
        {
            return new ObservableCollection<int>() { 1996 };
        }
    }
}
