using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.GetSODListServiceReference;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSODListClient client = new GetSODListClient();
            var results = client.GetSODSList();
            if(results!=null && results.Any())
            {
                foreach(var result in results)
                {
                    var jsonResult = JsonConvert.SerializeObject(result);
                    Console.WriteLine(jsonResult);
                }                
            }
            
            Console.ReadLine();
        }
    }
}
