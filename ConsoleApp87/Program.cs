using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

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
            IAsyncResult asyncResult = bp.BeginInvoke(10, 10, new AsyncCallback(AddComplete), 
                "Main() thanks you for adding these numbers.\n");
            int k = 0;

            //Assume other work is performed here...
            while(!isDone)
            {
                k++;
            }      
            
            //Do other work on primary thread...
            Console.WriteLine("Doing more work in Main()!\n");

            //Obtain the result of the Add() method when ready.
            
            Console.WriteLine("Now the k is :{0}\n", k);
            Console.ReadLine();
        }

        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);
         
            return x + y;
        }

        static void AddComplete(IAsyncResult asyncResul )
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete!\n");

            //Now get the result.
            AsyncResult ar = (AsyncResult)asyncResul ;
            BinaryOp bo = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10+10 is {0}.\n\n\n", bo.EndInvoke(asyncResul));

            //Retrieve the informational object and cast it to string.
            string msg = (string)asyncResul.AsyncState;
            Console.WriteLine("\n{0}\n\n", msg);
            isDone = true;
        }
    }
}
