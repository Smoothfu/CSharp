using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp130
{
    class Program
    {
        //Create a new Mutex.The creating thread does not own the mutex.
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with the CLR Thread Pool*****\n");
            Console.WriteLine("Main thread started. ThreadID={0}\n", Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);


            //Queue the method ten times
            for(int i=0;i<10;i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }

            Console.WriteLine("All tasks queued!\n");
            Console.ReadLine();
        }

        private void StartThreads()
        {
            //Create the threads that will use the protected resource.
            for(int i=0;i<numThreads;i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newThread.Start();
            }
        }


        //This method represents a resource that must be synchronized so that only one thread at a time can enter

        private static void UseResource()
        {
            //Wait until it is safe to enter. and do not enter if the request times out.
            Console.WriteLine("{0} is requesting the mutex!\n", Thread.CurrentThread.Name);

            if(mut.WaitOne(1000))
            {
                Console.WriteLine("{0} has entered the protected area!\n", Thread.CurrentThread.Name);
                //Place code to access non-critical non-reentrant resources here.
                //simulate some work.
                Thread.Sleep(500);

                Console.WriteLine("{0} is leaving the protected area!\n", Thread.CurrentThread.Name);

                //Release the mutex
                mut.ReleaseMutex();
                Console.WriteLine("{0} has released the mutex.\n", Thread.CurrentThread.Name);
            }
            else
            {
                Console.WriteLine("{0} will not acquire the mutex\n", Thread.CurrentThread.Name);
            }  
        }

        private static void ThreadProc()
        {
            for(int i=0;i<numIterations;i++)
            {
                UseResource();
            }
        }

        ~Program()
        {
            mut.Dispose();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Now is {0}, Param is :{1}\n", DateTime.Now.ToString("yyyyMMddHHmmssfff"),state.ToString());
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
    
    public class Printer 
    {
        private static object lockObj = new object();
        public void PrintNumbers()
        {
            lock(lockObj)
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("I is {0},and now is {1}\n", i, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                }
            }            
        }
    }
}
