using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp187.ServiceReference1;

namespace ConsoleApp187
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(null);
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            ServiceReference1.Service1Client proxy = new Service1Client();
            string result = proxy.DoWork(10000);
            Console.WriteLine("The {0} result is {1}\n", 10000, result);

            string res = proxy.DoWork(100);
            Console.WriteLine("The {0} result is {1}\n", 100, res);

            string addResult=proxy.Add(10000, 100000);
            Console.WriteLine(addResult);

            Task<int> intAddResult =proxy.AddMethodAsync(100000, 10000000);

            Console.WriteLine(string.Format("{0}+{1}={2}\n", 100000, 10000000, intAddResult.Result));
            Console.ReadLine();
        }
    }
}
