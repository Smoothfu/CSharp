using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp93
{
    class Program
    {
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
            Console.WriteLine("Time is :{0}\n", DateTime.Now.ToLongTimeString());
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

    public class Printer
    {
        public void PrintNumbers()
        {
            for(int i=0;i<100000;i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
