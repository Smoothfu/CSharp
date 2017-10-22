using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp87
{
    class Program
    {
        public delegate void PrintDelegate(string msg);
        public static void Print(string msg)
        {
            Console.WriteLine("Asynchronous method begin to execute: " + msg);
            Thread.Sleep(500);
        }
        static void Main(string[] args)
        {
            PrintDelegate del = Print;
            Console.WriteLine("The main thread.");

            IAsyncResult result = del.BeginInvoke("Hello World", null, null);
            Console.WriteLine("The main thread is continuing executing");
            //When invoke the BeginInvoke as the asynchronously,if it did not complete,the EndInvoke will be pending until the method complete/
            del.EndInvoke(result);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine(); 
        }
    }
}
