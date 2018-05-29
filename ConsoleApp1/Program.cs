using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfServiceLibrary2.Service1 obj = new Service1();
            string strResult = obj.AddMethod(10000, 132324887);
            Console.WriteLine(strResult);
            Console.ReadLine();
        }
    }
}
