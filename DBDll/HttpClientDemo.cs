using System;
using System.IO;
using System.Net.Http;

namespace DBDll
{
    public class HttpClientDemo
    {
        public static void HttpClientShow(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(url);            
            Console.WriteLine(response.Result);
            string textFile = Directory.GetCurrentDirectory() + "//" + "web.txt";
            using(StreamWriter webWriter=new StreamWriter(textFile,true))
            {
                webWriter.WriteLine(response.Result+"\n");
            }
            
        }        
    }
}
