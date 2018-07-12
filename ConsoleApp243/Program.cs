using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp243
{
    class Program
    {
        static double dayPrice = 4.0;
        static double nightPrice = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("The managedThreadId in main is {0}\n", Thread.CurrentThread.ManagedThreadId);
            Thread thread = new Thread(() =>
              {
                  Console.WriteLine(DateTime.Now);
              });
            thread.Start();
            Console.ReadLine();
        }

        static double GetMoney(DateTime inTime,DateTime outTime)
        {
            double totalMoney = 0.0;
            return totalMoney;
        }
    }
}
