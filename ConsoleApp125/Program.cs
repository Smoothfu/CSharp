using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp125
{
    class Program
    {
        // 0 for false,1 for true.
        private static int usingResource = 0;
        private const int numThreadIterations = 5;
        private const int numThreads = 10;

        static void Main(string[] args)
        {
            Thread myThread;
            for(int i=0;i<numThreads;i++)
            {
                myThread = new Thread(new ThreadStart(MyThreadProc));
                myThread.Name = string.Format("Thread {0}\n", i + 1);

                //Wait a random amount of time before starting next thread.
                myThread.Start();
            }

            Console.ReadLine();
        }

        //a simple method that denies reentrancy.
        static bool UseResource()
        {
            //0 indicates that the method is not in use.
            if(0==Interlocked.Exchange(ref usingResource,1))
            {
                Console.WriteLine("{0} acquired the lock\n", Thread.CurrentThread.Name);

                //Code to access a resource that is not thread safe would go here.
                //simulate some work.
                //Thread.Sleep(500);

                Console.WriteLine("{0} existing lock\n", Thread.CurrentThread.Name);

                //Release the lock.
                Interlocked.Exchange(ref usingResource, 0);
                return true;
            }
            else
            {
                Console.WriteLine(" {0} was denied the lock!\n", Thread.CurrentThread.Name);
                return false;
            }
        }


        private static void MyThreadProc()
        {
            for(int i=0;i<numThreadIterations;i++)
            {
                UseResource();

                //Wait 1 second before next attempt;
                //Thread.Sleep(1000);
            }
        }
    }
}
