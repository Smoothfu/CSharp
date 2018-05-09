using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp166
{
    class Program
    {
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {

            Console.WriteLine("*****Fun with the CLR Thread Pool*****\n");
            Console.WriteLine("Main thread started. ThreadId={0}\n", Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);


            //Queue the method ten times.
            for(int i=0;i<10;i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }

            Console.WriteLine("All tasks queued"); 
           
            Console.ReadLine();
        }   
        
        static void PrintTime(Object state)
        {
            Console.WriteLine("Time is {0},Param is {1}\n", DateTime.Now.ToString(), state.ToString()); 
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
     

    public class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("The PrintNumbers() thread Id is {0}\n", Thread.CurrentThread.ManagedThreadId);
            for(int i=0;i<10;i++)
            {
                Console.Write("{0} \t",i);
            }

            Console.WriteLine("\n\n\n\n\n");
        }
    }
    
}
