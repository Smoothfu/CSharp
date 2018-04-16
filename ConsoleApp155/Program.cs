using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp155
{
    class Program
    {
        static int x = 100000, y = 200000000;
        delegate void AddDel(ref int x, ref int y);
        static void Main(string[] args)
        {
            AddDel addDel = new AddDel(AddMethod);
            addDel(ref x, ref y);
            
            Console.ReadLine();
        }

        static void AddMethod(ref int x, ref  int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            x = x + 1000;
            y = y + 1000;
            Console.WriteLine("Now x is {0},y is {1}", x, y);
        }
    }
}
