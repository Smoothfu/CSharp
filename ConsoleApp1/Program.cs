using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary4;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfServiceLibrary4.Service1 client = new Service1();
            int result = client.AddMethod(10, 100000000);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
