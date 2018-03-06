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
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads*****\n");
            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.
            Thread[] threads = new Thread[10];
            for(int i=0;i<10;i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }

            //Now start each one.
            foreach(Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }
    }

    public class Printer
    {
        //Lock token.

        private object threadLock = new object();

        public void PrintNumbers()
        {
            //use the lock token.
            lock(threadLock)
            {
                for (int i = 0; i < 10; i++)
                {
                    //put thread to sleep for a random amount of time.
                    Random rnd = new Random();
                    
                    Console.Write(i + "\t");
                }
            }
           
            Console.WriteLine();
        }
    }
}
