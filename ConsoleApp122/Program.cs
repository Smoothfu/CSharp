using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp122
{
    //A C# delegate type.
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*****Async Delegate Invocation*****\n");

            //Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Invoke Add() on a secondary thread.
            BinaryOp bo = new BinaryOp(Add);
            IAsyncResult iftAR = bo.BeginInvoke(10, 10, null, null);

            //Do other wokr on primary thread...
            Console.WriteLine("Doing more work in Main()!\n");

            //Obtain the result of the Add() method when ready.
            int answer = bo.EndInvoke(iftAR);

            Console.WriteLine("10+10 is {0}\n", answer);

            Console.ReadLine();
        }         
         
        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

           

            return x + y;
        }
    }
}
