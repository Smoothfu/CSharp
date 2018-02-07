using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp103
{
    public delegate int BinaryDel(int x, int y);
    class Program
    {
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("*****AsyncCallbackDelegate Example*****\n");
            Console.WriteLine("Main() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            BinaryDel del = new BinaryDel(Add);
            IAsyncResult asyncResult = del.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null);

            while(!isDone)
            {
                Console.WriteLine("Now is  {0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-sss:fff"));
            }

            Console.WriteLine("This is the end of the Main thread!\n");
            Console.ReadLine();
        }

        static int Add(int x,int y)
        {
            Console.WriteLine("Add() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult asyncResult)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete!\n");
            isDone = true;
        }
    }
}
