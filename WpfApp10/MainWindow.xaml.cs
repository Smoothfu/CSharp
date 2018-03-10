using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string theEBook= @"The WebClient class is a member of System.Net. This class provides a number of methods for sending
data to and receiving data from a resource identified by a URI.As it turns out, many of these methods
have an asynchronous version, such as DownloadStringAsync(). This method will spin up a new thread
from the CLR thread pool automatically.When the WebClient is done obtaining the data, it will fire the
DownloadStringCompleted event, which you are handling here using a C# lambda expression. If you were to
call the synchronous version of this method (DownloadString()), the form would appear unresponsive for
quite some time.
The Click event hander for the btnGetStats Button control is implemented to extract the individual
words contained in theEBook variable and then pass the string array to a few helper functions for processing
as follows:
private void btnGetStats_Click(object sender, EventArgs e)
    {
        // Get the words from the e-book.
        string[] words = theEBook.Split(new char[]
        { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
        StringSplitOptions.RemoveEmptyEntries);
        // Now, find the ten most common words.
        string[] tenMostCommon = FindTenMostCommon(words); ";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void download_Click(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, ergs) =>
            {
                theEBook = ergs.Result;
                tbx.Text = theEBook;
            };

            //The project Guteberg EBook of A Tale of Two Cities,
            wc.DownloadStringTaskAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));

        }

        private void GetStats_Click(object sender, RoutedEventArgs e)
        {
            //Get the words from the e-book.
            string[] words = theEBook.Split(new char[]
            {
                ' ','\u000A',',','.',';',':','-','?','/'
            }, StringSplitOptions.RemoveEmptyEntries);

            //Now,find the ten most common words.
            string[] tenMostCommon = FindTenMostCommon(words);


            //Get the longest word.
            string longestWord = FindLongestWord(words);

            //Now that all tasks are complete,build a string to show all stats in a message box.
            StringBuilder bookStats = new StringBuilder("Ten most Common Words are: \n");
            foreach(string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }

            bookStats.AppendFormat("Longest word is :{0}\n", longestWord);
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book Info");
       
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
