using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp200
{
    class Program
    {
        static int x = 36245645, y = 3453454;
        static void Main(string[] args)
        {
            Thread newThread = new Thread(() =>
              {
                  AddMethod(x,y);
              });
            newThread.Start();
            
            Console.ReadLine();

        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
