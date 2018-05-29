using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ConsoleApp191
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string strResult=client.AddMethod(1000000, 23462456);
            Console.WriteLine(strResult);
            Console.ReadLine();
        }
    }
}
