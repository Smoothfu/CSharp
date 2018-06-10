using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        string theEBook = string.Empty;
        private CancellationTokenSource cts = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        //Download
        private async void button1_Click(object sender, EventArgs e)
        {
            this.Text = DoWork();
        }

        private void ProcessIntData()
        {
            //Get a very large array of integers.
            int[] source = Enumerable.Range(1, 100000000).ToArray();

            //Find the numbers where num%3==0 is true,returned in descending order.
            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cts.Token)
                                  where num % 3 == 0 orderby num descending
                                  select num).ToArray();
                MessageBox.Show(string.Format("Found {0} numbers that match query!", modThreeIsZero.Count()));
            }
            catch(OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    MessageBox.Show(ex.Message);
                });
            }

        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            theEBook = e.Result;
            textBox1.Text = theEBook;
        }

        //Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            ////Get the words from the e-book
            //string[] words = theEBook.Split(new char[] {' ','\u000A',',','.',';',':','-','?','/' },StringSplitOptions.RemoveEmptyEntries);

            ////Now find the ten most common words.
            //string[] tenMostCommon = null;

            ////Get the longest word.
            //string longestWord = string.Empty;

            //Parallel.Invoke(() =>
            //{
            //    //Now,find the ten most common words.
            //    tenMostCommon = FindTenMostCommon(words);
            //},
            //()=>
            //{
            //    //Get the longest word.
            //    longestWord = FindLongestWord(words);
            //});

            ////Now that all tasks are complete,build a string to show all stats in a message box.
            //StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            //foreach(string str in tenMostCommon)
            //{
            //    bookStats.AppendLine(str);
            //}

            //bookStats.AppendFormat("Longest word is :{0}\n", longestWord);
            //bookStats.AppendLine();
            //MessageBox.Show(bookStats.ToString(), "Book Inof");
            cts.Cancel();
        }

        private string[] FindTenMostCommon(string[] words)
        {
            if(words==null || words.Length<1)
            {
                return null;
            }

            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;
            string []commonWords = (frequencyOrder.Take(10)).ToArray();

            return commonWords;
        }

        private string FindLongestWord(string[] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }

        //See below for code walkthrough...
        private Task<String> DoWork()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work!";
            });
        }
    }
}
