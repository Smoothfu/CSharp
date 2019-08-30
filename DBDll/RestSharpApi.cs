using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace DBDll
{
    public class RestSharpApi
    {
        public static void GetWebResonse(string baseUrl = "https://api.github.com/repos/restsharp/restsharp/releases")
        {            
            var client = new RestClient(baseUrl);
            IRestResponse response = client.Execute(new RestRequest());
            //return the formatted json string from a clumsy json string.
            var releases = JArray.Parse(response.Content);
            Console.WriteLine(releases);
        }
    }
}
