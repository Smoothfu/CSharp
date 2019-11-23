using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace ConsoleApp392
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClientDownloadDemo();
            Console.ReadLine();
        }

        static void WebClientDownloadDemo()
        {
            string url = "https://go.microsoft.com/fwlink/?linkid=866662";
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            Console.WriteLine($"Started at {DateTime.Now.ToString("yyyyMMddHHmmssffff")}"); 
            webClient.DownloadFileAsync(new Uri(url), "SSMS2019.exe");
        }

        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed!");
        }

        private static void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Debug.WriteLine($"{e.UserState?.ToString()}    downloaded {e.BytesReceived} of {e.TotalBytesToReceive} bytes. {e.ProgressPercentage} % complete...");       
            Console.WriteLine($"{e.UserState?.ToString()}    downloaded {e.BytesReceived} of {e.TotalBytesToReceive} bytes. {e.ProgressPercentage} % complete...");
        }

        static void DownloadByWebRequest()
        {
            string url = "https://go.microsoft.com/fwlink/?linkid=2108895&amp;clcid=0x409";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                using (Stream fileStream = File.OpenWrite("ssms.exe"))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = responseStream.Read(buffer, 0, 4096);
                    while (bytesRead > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, 4096);
                    }
                }
            }
        }
        static void EventDemo()
        {
            Adult adult = new Adult(18);
            adult.AdultEvent += Adult_AdultEvent;
            adult.Age = 20;
        }

        private static void Adult_AdultEvent(object sender, AdultArgs e)
        {
            string msg = string.Empty;
            int newAge = e.AdultAge;
            if(newAge>=18)
            {
                msg = "Adult";
            }
            else
            {
                msg = "Adolescent";
            }
            Console.WriteLine($"The newly updated age is {newAge} and it's {msg} ");
        }
    }        

    public class AdultArgs
    {
        public int AdultAge { get; set; }
        public AdultArgs(int age)
        {
            AdultAge = age;
        }
    }

    public class Adult
    {
        public event EventHandler<AdultArgs> AdultEvent;

        public Adult(int adultAge)
        {
            Age = adultAge;
        }

        private int ageValue;
        public int Age
        {
            get
            {
                return ageValue;
            }
            set
            {
                if(value!=ageValue)
                {
                    ageValue = value;
                    RaisePropertyChanged(value);
                }
            }
        }

        private void RaisePropertyChanged(int value)
        {
            AdultEvent?.Invoke(this, new AdultArgs(value));
        }
    }

}
