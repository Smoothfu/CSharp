using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;

namespace ConsoleApp193
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfServiceLibrary1.Service1 serviceObj = new Service1();
            string result = serviceObj.AddMethod(100000000, 1000000);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
