using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp87
{
    delegate int BinaryOp(int x, int y);
    class Program
    {
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("*****AsyncCallbackDelegate Example*****!\n");

            //Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Invoke Add() on a secondary thread.
            BinaryOp bp = new BinaryOp(Add);
            IAsyncResult asyncResult = bp.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null);
            int k = 0;

            //Assume other work is performed here...
            while(!isDone)
            {
                k++;
            }      
            
            //Do other work on primary thread...
            Console.WriteLine("Doing more work in Main()!\n");

            //Obtain the result of the Add() method when ready.
            int answer = bp.EndInvoke(asyncResult);
            Console.WriteLine("10+10 is {0}!\n", answer);
            Console.WriteLine("Now the k is :{0}\n", k);
            Console.ReadLine();
        }

        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);
         
            return x + y;
        }

        static void AddComplete(IAsyncResult asyncResult)
        {
            Console.WriteLine("AddComplete invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete!\n");
            isDone = true;
        }
    }
}
