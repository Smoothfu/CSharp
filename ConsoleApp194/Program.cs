using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp194
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string strResult=client.AddMethod(10000000, 100000000);
            Console.WriteLine(strResult);
            Console.ReadLine();
        }
    }
}
