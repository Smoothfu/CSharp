using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts; 

namespace ConsoleApp157
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {

            Console.WriteLine("*****Fun with the CLR Thread Pool*****\n");

            Console.WriteLine("Main thread started.ThreadID={0}\n", Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);

            //Queue the method ten times.
            for(int i=0;i<10;i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }

            Console.WriteLine("All tasks queued!\n");
            Console.ReadLine();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Time is :{0},Param is:{1}\n", DateTime.Now.ToLongTimeString(),state.ToString());
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = state as Printer;
            if(task!=null)
            {
                task.PrintNumbers();
            }
        }
    }

    class AddParams
    {
        public int a, b;

        public AddParams(int numb1,int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }

    [Synchronization]
    class Printer:ContextBoundObject
    {
        public void PrintNumbers()
        {
            for(int i=0;i<10;i++)
            {
                //Put thread to sleep for a random amount of time.
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(5));
                Console.WriteLine("The i is {0},and now is {1}\n", i, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            }
        }
    }
}
