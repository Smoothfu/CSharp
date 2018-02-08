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
            int x = 10000, y = 10000;
            Console.WriteLine("*****The beginning of the main thread!*****\n");

            Thread thread = new Thread(new ThreadStart(new Action(()=>
            {
                (new Program()).AddMethod(x, y);
            }))); 

            thread.Start();

            Console.WriteLine("\n\n\nThe end of the Main thread!\n");

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

        private void AddMethod(int x,int y)
        {
            for(int i=0;i<100000;i++)
            {
                Console.WriteLine("{0}+{1}={2} and now is :{3}\n", x, y, x + y,DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
                x = x + 1000;
                y = y + 1000;
            }
        }
    }
}
