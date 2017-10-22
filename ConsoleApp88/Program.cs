using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp88
{
    class Program
    {
        public delegate void PrintDelegate(string msg);
        static void Main(string[] args)
        {
            PrintDelegate del = Print;
            Console.WriteLine("The main thread.");
            IAsyncResult result = del.BeginInvoke("Hello World.", null, null);
            Console.WriteLine("The main thread is continuing...");
            result.AsyncWaitHandle.WaitOne(-1, false);

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void Print(string msg)
        {
            Console.WriteLine("Begin to run the asynchronous thread: " + msg);
        }
    }
}
