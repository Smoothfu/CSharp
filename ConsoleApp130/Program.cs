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
            Console.WriteLine("*****Working with Timer type*****\n");

            //Create the delegate for the Timer type.
            TimerCallback timerCallback = new TimerCallback(PrintTime);

            //Establish timer settings.
            Timer t = new Timer(
                timerCallback, //The TimerCallback delegate object.
                "Hello From Main",           //Any info to pass into the called method
                0,              //Amount of time to wait before starting.
                1);          //Interval of time between calls in milliseconds.

            Console.WriteLine("Hit key to terminate...");
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
    }

    //All methods of Printer are now thread safe!
    [Synchronization]
    public class Printer:ContextBoundObject
    {
        public void PrintNumbers()
        {
            for(int i=0;i<100;i++)
            {
                Console.WriteLine("I is {0},and now is {1}\n", i, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            }
        }
    }
}
