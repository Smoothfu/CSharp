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
using System.IO;
using System.Drawing;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //New Form-level variable.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //This will be used to tell all the worker threads to stop!
            cancelToken.Cancel();
            //Start a new task to process the files.
            Task.Factory.StartNew(() =>
            {
                ProcessImages();
            });           
        }

        private void ProcessImages()
        {
            //Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancelToken.Token;

            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            //Load up all *.jpg files,and make a few folder for the modified data.
            string path = @"C:\Users\Default\Pictures";
            string[] allFiles = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            string newDir = @"C:\Users\Default\Pictures\NewImages";
            Directory.CreateDirectory(newDir);

            string fullName = "";
            string threadMsg = "";

            try
            {
                Parallel.ForEach(allFiles, parallelOptions, x =>
                {
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                    fullName += System.IO.Path.GetFullPath(x) + "\t\t";

                    using (Bitmap bitMap = new Bitmap(x))
                    {
                        //Invoke on the form object,to allow secondary threads to access controls in a thread-safe manner.
                        this.Dispatcher.BeginInvoke((Action)delegate
                        {
                            threadMsg += Thread.CurrentThread.ManagedThreadId.ToString() + "\t\t";
                        });
                    }
                });
            }

            catch(OperationCanceledException ex)
            {
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    MessageBox.Show(threadMsg);
                });
            }
            //Process the image data in a parallel manner!
          

            MessageBox.Show(fullName);
            
        }
    }
}
