using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp88
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads!*****\n");

            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.

            Thread[] threads = new Thread[10];
            
            for(int i=0;i<10;i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }

            //Now start each one.
            foreach(Thread thread in threads)
            {
                thread.Start();
            }
            Console.ReadLine();
        }

        static void Add(object data)
        {
            if(data is AddParams)
            {
                Console.WriteLine("Id of thread in Add(): {0}\n", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0}+{1}={2}\n", ap.X, ap.Y, ap.X + ap.Y);

                //Tell other thread we are done.
                waitHandle.Set();
            }
        }
    }

    public class AddParams
    {
        public int X { get; set; }
        public int Y { get; set; }

        public AddParams(int x,int y)
        {
            this.X = x;
            this.Y = y;
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
                Console.WriteLine("Name: {0}\n", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    //Put thread to sleep for a random amout of time.
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}\t", i);
                }
                Console.WriteLine("\n");
            }
            
        }
    }
}
