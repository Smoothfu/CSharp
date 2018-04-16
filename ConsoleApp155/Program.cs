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
        static int x = 10000000, y = 10000000;
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
              {
                  AddMethod(ref x, ref y);
              });

            thread.Start();
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
