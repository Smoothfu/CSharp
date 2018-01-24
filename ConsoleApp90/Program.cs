using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp90
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with the CLR Thread Pool*****\n");
            Console.WriteLine("Main thread started. ThreadId={0}\n", Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);


            //Queue the method ten  times.
            for(int i=0;i<10;i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine("All Tasks queued!\n");
            Console.ReadLine();
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }

        static void PrintTime(object obj)
        {
            Console.WriteLine("Time is :{0}, Param is :{1}\n", DateTime.Now.ToLongTimeString(),obj.ToString());
        }
    }

    [Synchronization]
    public class Printer:ContextBoundObject
    {

        public void PrintNumbers()
        {

            //Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);

            //Print out numbers
            Console.WriteLine("Your numbers:");
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(5));
                Console.Write("{0},", i);
            }
            Console.WriteLine("\n\n");
        }
    }
}
