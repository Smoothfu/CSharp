using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp349.MathServiceWCF;
using ConsoleApp349.ToUpperServiceWCF;

namespace ConsoleApp349
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10, y = 20;
            MathServiceWCFClient mathClient = new MathServiceWCFClient();
            int result = mathClient.Add(10, 20);
            Console.WriteLine($"{x}+{y}={x + y}");

            string str = "this is small case";
            ToUpperServiceClient upperServiceWCFClient = new ToUpperServiceClient();
            string upperCase = upperServiceWCFClient.StringToUpper(str);
            Console.WriteLine($"small case:{str},upper case:{upperCase}");

            Console.ReadLine();
        }
    }
}
