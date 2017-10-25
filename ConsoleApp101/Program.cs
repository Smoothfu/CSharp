using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp101
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentBytes = GC.GetTotalMemory(true);
            string str1 = "Hello World";
            string str2 = "Hello world";

            //if (str1.ToUpper() == str2.ToUpper())
            //{
            //    Console.WriteLine("Equal");
            //}


            if ((string.Compare(str1, str2, StringComparison.InvariantCultureIgnoreCase)) == 0)
            {
                Console.WriteLine("Equal");
            }

            var objSize = GC.GetTotalMemory(true) - currentBytes;
            Console.WriteLine(objSize.ToString());
            Console.ReadLine();
        }
    }
}
