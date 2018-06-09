using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApp216
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread thread = new Thread(() =>
              {
                  Add(100, 2000000);
              });
            Console.WriteLine(thread.ManagedThreadId);
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

    }
}
