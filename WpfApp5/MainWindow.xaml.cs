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
using System.Net;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //New Form-level variable.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        string theBookNames;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            theBookNames = "The C# principle,The Common Language Runtime,Data Structure,Windows Presentation Foundation,NetWork,Big Data,Data Base,Task Parallel Libray,Cloud,Artificial Intelligence,Software Engineer,Software Projects,HardWare,IOT,Web,Internet,Operating System,Compile Language";

            //Get the words from the e-book.
            string[] words = theBookNames.Split(new char[] {','},
                StringSplitOptions.RemoveEmptyEntries);

            //Now ,find the ten most common words
            string[] tenMostCommon = FindTenMostCommon(words);

            //Get the longest word.
            string longestWord = FindLongestWord(words);

            //Now that all tasks are complete,build a string to show all stats in a message box.
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach(string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }

            bookStats.AppendFormat("Longest word is :{0}\n", longestWord);
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book Info");
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

        private string FindLongestWord(string [] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
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
    }
}
