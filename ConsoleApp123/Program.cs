using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp123
{
    class Program
    {

        //0 for false, 1 for true.
        private static int usingResource = 0;
        private const int numThreadIterations = 5;
        private const int numThreads = 10;

        static void Main(string[] args)
        {
            Thread myThread;
            Random rnd = new Random();

            for(int i=0;i<numThreads;i++)
            {
                myThread = new Thread(new ThreadStart(MyThreadProc));
                myThread.Name = string.Format("Thread {0}\n", i + 1);

                //wait a random amount of time before starting next thread.
                Thread.Sleep(rnd.Next(0, 1000));
                myThread.Start();


            }
            
            Console.ReadLine();
        }

        private static void MyThreadProc()
        {
            for(int i=0;i<numThreadIterations;i++)
            {
                UseResource();

                //wait 1 second before next attempt.
                Thread.Sleep(1000);
            }
        }

        //A simple method that denies reentrancy.
        static bool UseResource()
        {
            //0 indicates that the method is not in use.
            if (0 == Interlocked.Exchange(ref usingResource, 1))
            {
                Console.WriteLine("{0} acquired the lock!\n", Thread.CurrentThread.Name);

                //Code to access a resource that is not thread safe would go here.

                //simulate some work.
                Thread.Sleep(500);
                Console.WriteLine("{0} existing lock", Thread.CurrentThread.Name);

                //Release the lock
                Interlocked.Exchange(ref usingResource, 0);
                return true;            
            }

            else
            {
                Console.WriteLine(" {0} was denied the lock.\n", Thread.CurrentThread.Name);
                return false;
            }
        }
    }

    public class Printer
    {
        //Lock token.

        private object threadLock = new object();

        public void PrintNumbers()
        {
            Monitor.Enter(threadLock);
            try
            {
                //Display Thread info.
                Console.WriteLine("\n\n-> {0} is executing PrintNumbers()!\n", Thread.CurrentThread.Name);

                //Print out numbers.
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(i + "\t");
                }
            }

            finally
            {
                Monitor.Exit(threadLock);
            }
            
           
            Console.WriteLine();
        }
    }
}
