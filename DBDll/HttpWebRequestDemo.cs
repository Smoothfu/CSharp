using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace DBDll
{
    public class HttpWebRequestDemo
    {
        public static void HttpWebRequestShow(string baseUrl = "https://api.github.com/repos/restsharp/restsharp/releases")
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(baseUrl);
            httpRequest.Method = "GET";
            httpRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36";
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string content = string.Empty;
            using(var responseStream=httpResponse.GetResponseStream())
            {
                using(var sr=new StreamReader(responseStream))
                {
                    content = sr.ReadToEnd();
                }
            }
            Console.WriteLine(content);
        }
    }
}
