using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp89
{
    class Program
    {
        public delegate void PrintDelegate(string msg);
        static void Main(string[] args)
        {
            PrintDelegate del = PrintInfo;
            Console.WriteLine("The main thread :" + Thread.CurrentThread.ManagedThreadId);
            IAsyncResult result = del.BeginInvoke("Hello world", null, null);
            Console.WriteLine("The main thread: " + Thread.CurrentThread.ManagedThreadId + " , continuing executing....");
            while (!result.IsCompleted)
            {
                Console.WriteLine(".");
                Thread.Sleep(500);
            }

            del.EndInvoke(result);

            Console.WriteLine("The main thread is " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }

        public static void PrintInfo(string msg)
        {
            Console.WriteLine("The current thread: " + Thread.CurrentThread.ManagedThreadId + "\t" + msg);
        }
    }
}
