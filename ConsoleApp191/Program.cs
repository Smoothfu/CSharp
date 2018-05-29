using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService1;
 

namespace ConsoleApp191
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfService1.Service1 obj = new Service1();
            string stringResult = obj.AddMethod(1323532, 34546456);
            Console.WriteLine(stringResult);
            Console.ReadLine();
        }
    }
}
