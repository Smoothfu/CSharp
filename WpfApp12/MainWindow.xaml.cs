using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void processBtn_Click(object sender, RoutedEventArgs e)
        {
            //Start a new "task" to process the ints.
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });

        }

        private void ProcessIntData()
        {
            //Get a very large array of integers.
            int[] source = Enumerable.Range(0, 100000000).ToArray();

            //Find the numbers where num%3==0 is true,returned in descending order.
            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token) where num % 3 == 0 orderby num descending select num).ToArray();

                MessageBox.Show(string.Format("Found {0} numbers that match query!\n", modThreeIsZero.Count()));
            }

            catch(OperationCanceledException ex)
            {
                this.Dispatcher.Invoke((Action)delegate
                {
                    MessageBox.Show(ex.Message);
                });
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
