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
using System.Windows.Navigation;

namespace WPFPrism.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Page
    {
        public WelcomeView()
        {
            InitializeComponent();
            _mainFrame.Navigate(new Shell());

            Uri winUri = new Uri("pack://application:,,,/WPFPrism;component/Shell.xaml", UriKind.Relative);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(winUri);
            ns.Navigate("");
        }
    }
}
