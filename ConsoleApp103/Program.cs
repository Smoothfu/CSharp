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
        static void Main(string[] args)
        {
            Console.WriteLine("*****Async Delegate Invocation*****\n");

            //Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Invoke Add() on a secondary thread.
            BinaryDel del = new BinaryDel(Add);
            IAsyncResult asyncResult = del.BeginInvoke(10, 10, null, null);

            //Do other work on primary thread...
            Console.WriteLine("Doing more work in Main()!\n");

            //Obtain the result of the Add() method when ready.
            int answer = del.EndInvoke(asyncResult);

            Console.WriteLine("10+10={0}\n", answer);

            Console.WriteLine("This is the end of the Main() thread!\n");

            Console.ReadLine();
        }

        static int Add(int x,int y)
        {
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
