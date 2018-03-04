using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp122
{
    //A C# delegate type.
    public delegate int BinaryOp(int x, int y);

    delegate int SomeDelegate(int x);
    class Program
    {
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("*****AsyncCallbackDelegate Example*****\n");
            Console.WriteLine("Main() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            BinaryOp bo = new BinaryOp(Add);
            IAsyncResult iftAR = bo.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers.!\n");

            //Assume other work is performed here...
            while(!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Now is {0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
            }
              
            Console.ReadLine();
        }         
         
        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(1000);

            return x + y;
        }

        static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete!\n");

            //Now get the result.
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp bo = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10+10 is {0}.\n", bo.EndInvoke(itfAR));

            //Retrieve the informational object and cast it to string.
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);

            isDone = true;
        }

        static int SquareNumber(int a)
        {
            Console.WriteLine("SquareNumber Invoked.Processsing...");
            Thread.Sleep(2000);
            return a * a;
        }
    }
}
