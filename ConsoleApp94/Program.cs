using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp94
{
    class Program
    {
        static void Main(string[] args)
        {
            //new a thread by annoymous delegate
            Thread thread = new Thread(delegate ()
              {
                  Console.WriteLine("Create a new thread by annoymous delegate!");
              });

            thread.Start();

            //new a thread by Lambda Expression
            Thread thread2 = new Thread(() => Console.WriteLine("New a thread by Lambda Expression"));
            thread2.Start();
            Console.ReadLine();
        }
    }
}
