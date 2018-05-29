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
            string firstResult = obj.GetData(134324534);
            Console.WriteLine(firstResult);

            string secondResult = obj.AddMethod(45324, 345234534);
            Console.WriteLine(secondResult);
            Console.ReadLine();
        }
    }
}
