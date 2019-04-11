using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Windows.Forms; 
using Eventdll;

namespace ConsoleApp338
{
    class Program
    {
        static string logFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
        static void Main(string[] args)
        {
            Counter counter = new Counter(2);
            counter.ThresholdReached += Counter_ThresholdReached;
            Console.WriteLine("Press 'a' key to increase total");
            while(Console.ReadKey().KeyChar=='a')
            {
                Console.WriteLine("Adding one");
                counter.Add(1);
            }

        }

        private static void Counter_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"The threshold of {e.ThreshoId} was reached at {e.TimeReached}");
            Environment.Exit(0);
        }

        private static void Pub_SampleEvent(object sender, SampleEventArgs e)
        {
            Console.WriteLine(e.Text);
        }

        static void HttpClientDownload(string url)
        {
            try
            {
                using (WebClient downloadClient = new WebClient())
                {
                    downloadClient.DownloadFile(url, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf");
                    MessageBox.Show("Finished");
                }                    
            }
            catch (Exception ex)
            {
                LogMessage(ex.StackTrace);
            }
        }

        static void WebClientDownLoadString(string url)
        {
            try
            {
                using (WebClient downloadClient = new WebClient())
                {
                    string result = downloadClient.DownloadString(new Uri(url));
                    MessageBox.Show("Completed");                    
                }
            }
            catch(Exception ex)
            {
                LogMessage(ex.Message);
            }
        }       

        static void LogMessage(string logMsg)
        {
            using (StreamWriter logWriter = new StreamWriter(logFullName, true))
            {
                logWriter.WriteLine(logMsg);
            }
        }
    }

    public class ThresholdReachedEventArgs:EventArgs
    {
        public int ThreshoId { get; set; }
        public DateTime TimeReached { get; set; }
    }

    class Counter
    {
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        private int threshold;
        private int total;
        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if(total>=threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.ThreshoId = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }
        }

        private void OnThresholdReached(ThresholdReachedEventArgs args)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
