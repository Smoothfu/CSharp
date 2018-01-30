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
using System.Threading;
using System.Windows.Threading;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                BeginInvokeExample();
            });
        }

        private void InvokeMethodExample()
        {
            Thread.Sleep(5000);
            Dispatcher.Invoke(() =>
            {
                btn.Content = "By Invoke";
            });
        }

        private void BeginInvokeExample()
        {
            DispatcherOperation op = Dispatcher.BeginInvoke((Action)(() =>
            {
                btn.Content = "By BeginInvoke";
            }));
        }
    }
}
