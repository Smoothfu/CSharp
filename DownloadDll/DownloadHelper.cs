using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadDll
{
    public class DownloadHelper
    {
        static string logFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
        public  static void WebClientDownLoadString(string url)
        {
            try
            {
                using (WebClient downloadClient = new WebClient())
                {
                    string result = downloadClient.DownloadString(new Uri(url));
                    LogMessage(result);
                    MessageBox.Show("Completed");
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }

        public static void WebClientDownloadAsync(string url)
        {
            try
            {
                using (WebClient downClient = new WebClient())
                {                    
                    downClient.DownloadDataCompleted += DownClient_DownloadDataCompleted;
                    downClient.DownloadDataAsync(new Uri(url));                    
                }
            }
            catch(Exception ex)
            {
                LogMessage(ex.Message);
            }
        }

        static void downloadFinished()
        {
            MessageBox.Show("downloadFinished()");
        }

        private static void DownClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            byte[] results = e.Result;
            string stringResult = ASCIIEncoding.UTF8.GetString(results);
            LogMessage(stringResult);
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
