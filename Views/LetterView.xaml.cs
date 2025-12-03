using AMS2ChEd.ViewModels;
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
    /// <summary>
    /// Interaction logic for LetterView.xaml
    /// </summary>
    public partial class LetterView : Window
    {
        public LetterView(SeatSelectionModel seat, string playerName)
        {
            this.InitializeComponent();

            // create viewmodel with parameters
            var vm = new LetterViewModel(seat, playerName);

            // set as DataContext for bindings in XAML
            this.DataContext = vm;
        }
    }
}
