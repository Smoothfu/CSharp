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
             
            Dispatcher.Invoke(() =>
            {
                int sum = 0;
                for (int i=0;i<1000000000;i++)
                {

                    sum += i;
                }
                btn.Content = "By Invoke";
                win.Title = sum.ToString();
            });
        }

        private void BeginInvokeExample()
        {
            int sum = 0;
            
            DispatcherOperation op = Dispatcher.BeginInvoke((Action)(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    sum += i;
                }
                btn.Content = "By BeginInvoke";
                win.Title = sum.ToString();
            }));
        }
    }
}
