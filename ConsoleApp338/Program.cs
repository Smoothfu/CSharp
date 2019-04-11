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
            ComputeTime computeTime = new ComputeTime(10);
            computeTime.DateTimeEventHandler += ComputeTime_DateTimeEventHandler;
            computeTime.SetNewValue(100);
            Console.ReadLine();
        }

        private static void ComputeTime_DateTimeEventHandler(object sender, DateTimeEventArgs e)
        {
            Console.WriteLine($"Datetime is {e.Datetime},DateTimeString is {e.DateTimeString}");
        }

        private static void Counter_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"The threshold of {e.ThreshoId} was reached at {e.TimeReached}");
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
            catch (Exception ex)
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

    public class ThresholdReachedEventArgs : EventArgs
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

        public void SetCounterNewValue(int newValue)
        {
            if (newValue >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.ThreshoId = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
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

    public class DateTimeEventArgs : EventArgs
    {
        public string DateTimeString { get; set; }
        public DateTime Datetime { get; set; }
    }

    public class ComputeTime
    {
        public event EventHandler<DateTimeEventArgs> DateTimeEventHandler;
        public int TimeThreshold { get; set; }
        public ComputeTime(int threshold)
        {
            TimeThreshold = threshold;
        }

        public void SetNewValue(int newValue)
        {
            if (newValue >= TimeThreshold)
            {
                DateTimeEventArgs dateTimeEventArgs = new DateTimeEventArgs();
                dateTimeEventArgs.Datetime = DateTime.Now;
                dateTimeEventArgs.DateTimeString = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                OnDateTimeEventHandler(dateTimeEventArgs);
            }
        }

        private void OnDateTimeEventHandler(DateTimeEventArgs dateTimeEventArgs)
        {
            if(DateTimeEventHandler!=null)
            {
                DateTimeEventHandler(this, dateTimeEventArgs);
            }
        }
    }
}
