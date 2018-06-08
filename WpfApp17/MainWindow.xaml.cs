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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler myEvent;
        public MainWindow()
        {
            InitializeComponent();
            myEvent += MainWindow_myEvent;
        }

        private void MainWindow_myEvent(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.Source.ToString());
        }
    }
}
