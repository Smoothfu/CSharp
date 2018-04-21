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
using System.Reflection;
using System.Drawing;
using System.Net;

namespace WpfApp14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //New MainWindow level variable.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            //Start a new "task" to process the files.
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });           
        }

        private void ProcessFiles()
        {
            //Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancelToken.Token;
            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            //Load up all *.jpg files,and make a new folder for the modified data.
            string[] allFiles = Directory.GetFiles(@"C:\Users\Fred\Pictures", "*.jpg", SearchOption.AllDirectories);

            string newDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"\ModifiedFile";
            Directory.CreateDirectory(newDir);

            try
            {
                //Process the image data in a parallel manner!
                Parallel.ForEach(allFiles,parallelOptions, currentFile =>
                {
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                    string fileName = System.IO.Path.GetFileName(currentFile);

                    using (Bitmap bp = new Bitmap(currentFile))
                    {
                        bp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bp.Save(System.IO.Path.Combine(newDir, fileName));

                        //Print out the ID of the thread processing the current image.
                        this.Dispatcher.Invoke(() =>
                        {
                            this.tbx.Text += string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId) + Environment.NewLine;
                        });
                        Thread.Sleep(500);
                    }
                });

                this.Dispatcher.Invoke(() =>
                {
                    this.tbx.Text = "Done!";
                });
            }

            catch(OperationCanceledException ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.tbx.Text = ex.Message;
                });
            }           
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            //This will be used to tell all the worker threads to stop!
            cancelToken.Cancel();
        }

        private void download_Click(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {

                theEBook.Text = eArgs.Result;
                txtBook = theEBook;
            };

            //The project Gutenberg EBook of A Tale of Two Cities
            wc.DownloadStringTaskAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }

        private void getStats_Click(object sender, RoutedEventArgs e)
        {
            //Get the words from the e-book.
            string[] words = theEBook.Text.Split(new Char[] {' ','\u000A',',','.',';','-','?','/'},StringSplitOptions.RemoveEmptyEntries);

            //Now,find the ten most common words.
            string[] tenMostCommon =FindTenMostCommon(words);

            //Get the longest word.
            string longestWord = FindLongestWord(words);

            //Now that all tasks are complete,build a string to show all stats in a message box.
            StringBuilder bookStats = new StringBuilder("Ten most common words are:\n");
            foreach(string str in tenMostCommon)
            {
                bookStats.AppendLine(str);
            }

            bookStats.AppendFormat("Longest word is:{0}\n", longestWord);
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book info");
        }

        private string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }

        private string FindLongestWord(string[] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }
    }
}
