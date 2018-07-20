using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp248
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The main ManagedThreadId is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Thread thread = new Thread(() =>
              {
                  AddMethod(1334, 4764567);
              });
            thread.Start();
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("The AddMethod ManagedThreadId is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
