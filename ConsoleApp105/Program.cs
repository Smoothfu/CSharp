using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace ConsoleApp105
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        private static bool isDone;
        static void Main(string[] args)
        {
            Console.WriteLine("*****The beginning of the main thread!*****\n");
            BinaryOp bo = new BinaryOp(Add);
            IAsyncResult asyncResult = bo.BeginInvoke(10, 10, AddComplete, "Main() thanks you for adding these numbers.");

            while(!isDone)
            {
                Console.WriteLine("Now is :{0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
            }

            Console.WriteLine("The end of the main thread!\n");
            Console.ReadLine();
        }

        static void AddComplete(IAsyncResult asyncResult)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}\n",Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete\n");

            //Now get the result;

            AsyncResult ar = (AsyncResult)asyncResult;
            BinaryOp bo = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10+10 is {0}\n", bo.EndInvoke(asyncResult));

            //Retrieve the informational object and cast it to string.
            string msg = (string)asyncResult.AsyncState;
            Console.WriteLine(msg + "\n\n\n");
            isDone = true;
        }

        private static int Add(int x,int y)
        {
            return x + y;
        }
    }
}
