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

            Console.WriteLine("*****Primary Thread stats*****\n");

            //Obtain and name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            //Show details of hosting AppDomain/Context.

            Console.WriteLine("Name of current AppDomain:{0}\n", Thread.GetDomain().FriendlyName);

            Console.WriteLine("ID of current Context:{0}\n", Thread.CurrentContext.ContextID);

            //Print out some stats about this thread.
            Console.WriteLine("Thread name:{0}\n", primaryThread.Name);

            Console.WriteLine("Has thread started?:{0}", primaryThread.IsAlive);

            Console.WriteLine("Priority Level:{0}\n", primaryThread.Priority);

            Console.WriteLine("Thread State:{0}", primaryThread.ThreadState);
              
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
