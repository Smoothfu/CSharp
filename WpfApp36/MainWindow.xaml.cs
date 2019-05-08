using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace WpfApp36
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        

        private void btnDoSync_Click(object sender, RoutedEventArgs e)
        {
            int max = 10000;
            pbProgress.Value = 0;
            lbResults.Items.Clear();

            int results = 0;
            for (int i = 0; i < max; i++)
            {
                if (i % 7 == 0)
                {
                    lbResults.Items.Add(i);
                    results++;
                }
                System.Threading.Thread.Sleep(1);
                pbProgress.Value = Convert.ToInt32(((double)i / max) * 100);
            }
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + results);
        }

        private void btnDoAsync_Click(object sender, RoutedEventArgs e)
        {
            pbProgress.Value = 0;
            lbResults.Items.Clear();
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync(10000);
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + e.Result);
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
            if(e.UserState!=null)
            {
                lbResults.Items.Add(e.UserState);
            }
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int)e.Argument;
            int result = 0;
            for(int i=0;i<max;i++)
            {
                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if(i%7==0)
                {
                    result++;
                    (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                }
                else
                {
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);

                }
                System.Threading.Thread.Sleep(1);
            }
            e.Result = result;
        }
    }
}
