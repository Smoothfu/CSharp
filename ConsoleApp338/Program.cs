using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Windows.Forms;
using DownloadDll;

namespace ConsoleApp338
{
    class Program
    {
        static string logFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
        static void Main(string[] args)
        {
            string url = "https://stackoverflow.com/questions/45711428/download-file-with-webclient-or-httpclient";
            DownloadHelper.WebClientDownLoadString(url);
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
}
