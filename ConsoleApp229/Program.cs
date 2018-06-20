using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp229
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The ManagedThreadId in Main method is {0}\n", Thread.CurrentThread.ManagedThreadId);
            Task.Factory.StartNew(() =>
            {
                Add(100, 200);
            });
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("The ManagerThreadId in Add method is {0}\n", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
