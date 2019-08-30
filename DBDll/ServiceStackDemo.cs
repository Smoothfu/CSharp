using System;
using ServiceStack;

namespace DBDll
{
    public class ServiceStackDemo
    {
        public static void ServiceStackShow(string url)
        {
            var response= url.GetJsonFromUrl();
            Console.WriteLine(response);
        }
    }
}
