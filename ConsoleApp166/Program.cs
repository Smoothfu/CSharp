using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp166
{
    class Program
    {
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads*****\n");

            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.
            Thread[] allThreads = new Thread[10];

            for(int i=0;i<10;i++)
            {
                allThreads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                allThreads[i].Name = string.Format("Worker thread #{0}\n", i);
            }

            //Now start each one.
            foreach(Thread thread in allThreads)
            {
                thread.Start();
            }
            Console.ReadLine();
        }        
    }

    class AddParams
    {
        public int a, b;
        public AddParams(int num1,int num2)
        {
            a = num1;
            b = num2;
        }
    }

    public class Printer
    {

        //Lock token.
        private object threadLock = new object();
        public void PrintNumbers()
        {
            //Use the lock token.
            lock(threadLock)
            {
                Console.WriteLine("The PrintNumbers thread id is {0}\n", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 10; i++)
                {
                    //Put thread to sleep for a random amount of time.
                    Random rnd = new Random();
                    Thread.Sleep(rnd.Next(5));
                    Console.Write("{0}\t", i);
                }
                Console.WriteLine("\n\n\n\n\n");
            }            
        }
    }
}
