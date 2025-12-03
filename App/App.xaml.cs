using System.Configuration;
using System.Data;
using System.Windows;

namespace AMS2ChEd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            FrameworkElement.StyleProperty.OverrideMetadata(
                typeof(Window),
                new FrameworkPropertyMetadata((Style)Resources["GlobalWindowStyle"])
            );
        }
    }

}
