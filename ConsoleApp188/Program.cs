using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;

namespace ConsoleApp188
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfServiceLibrary1.Service1 obj = new Service1();
            string strResult = obj.GetData(10000000);
            Console.WriteLine(strResult);
            Console.WriteLine();
            string addStringResult = obj.AddMethod(1000000, 100000);
            Console.WriteLine(addStringResult);
            Console.ReadLine();
        }
    }
}
