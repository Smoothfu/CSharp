using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace ConsoleApp159
{
    class Program
    {
     static void Main(string[] args)
        {
           Task<int> str = AccessTheWebAsync();
            Console.WriteLine(str.Result);
            Console.ReadLine();
        }

        static async Task<int> AccessTheWebAsync()
        {
            //You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();

            //GetStringAsync returns a Task<string> that means that when you await the task you'll get a string 
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            //You can do work here that does not rely on the string from GetStringAsync .
             

            string urlContents = await getStringTask;
            return urlContents.Length;
        }
    }
}
