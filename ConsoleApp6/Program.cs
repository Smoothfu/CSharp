using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp6
{
    class Program
    {
        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        static void Subtract(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }
        static void Main(string[] args)
        {
            int x = 10, y = 20;
            Thread thred = new Thread(() =>
              {

                  Add(x, y);
                  Subtract(x, y);
              });
            thred.Start();
            Console.ReadLine();
        }
    }
}
