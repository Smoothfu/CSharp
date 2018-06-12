using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ConsoleApp1
{
    class Program
    {
        static int x = 10000, y = 10000;
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string addResult = client.AddMethod(x, y);
            Console.WriteLine(addResult);
            Console.WriteLine();

            string multiplyResult = client.MultiplyMethod(x, y);
            Console.WriteLine(multiplyResult);
            Console.ReadLine();
        }
    }
}
