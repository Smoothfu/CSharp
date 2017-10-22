using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp90
{
    class Program
    {
        public delegate void PrintDelegate(string msg);
        static void Main(string[] args)
        {

            PrintDelegate del = PrintInfo;
            Console.WriteLine("The main thread.");
            del.BeginInvoke("Hello World", PrintComplete, del);
            Console.WriteLine("The main thread is executing...");

            Console.ReadLine();
        }

        public static void PrintInfo(string msg)
        {
            Console.WriteLine("The current thread: " + msg);
        }

        public static void PrintComplete(IAsyncResult result)
        {
            (result.AsyncState as PrintDelegate).EndInvoke(result);
            Console.WriteLine("The current thread end." + result.AsyncState.ToString());
        }
    }
}
