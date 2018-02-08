using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp104
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("*****AsyncCallbackDelegate Example*****\n");
            Console.WriteLine("Main() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            BinaryOp bo = new BinaryOp(Add);
            IAsyncResult asyncResult = bo.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null);

            //Assume other work is performed here...
            while(!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working,and now is ：{0}\n",DateTime.Now.ToString("yyyy-MM-dd:hh-mm-sss:fff"));
            }


            Console.WriteLine("\n\n\n\n\nThe main thread is over!\n\n");
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
            Console.WriteLine("AddComplete() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete!\n");

            //Now get the result.
            AsyncResult ar = (AsyncResult)asyncResult;
            BinaryOp bo = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("In AddComplete 10+10 is {0}.\n", bo.EndInvoke(asyncResult));
            isDone = true;
        }
    }
}
