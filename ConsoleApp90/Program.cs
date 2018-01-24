﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp90
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads*****\n");

            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.

            Thread[] threadArray = new Thread[10];
            for(int i=0;i<10;i++)
            {
                threadArray[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threadArray[i].Name = string.Format("Worker thread #{0}\n", i);
            }

            //Now start each one.
            foreach(Thread thread in threadArray)
            {                
                thread.Start();
            }

            Console.ReadLine();
        }
    }

    public class Printer
    {
        //Lock token.
        protected object threadLock = new object();
        public void PrintNumbers()
        {
            //Use the lock token
            lock(threadLock)
            {
                //Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    //Put thread to sleep for a random amount of time.
                    Random rnd = new Random();
                    Thread.Sleep(1000 * rnd.Next(5));
                    Console.Write("{0}\t", i);
                }
                Console.WriteLine("\n\n");
            }            
        }
    }
}
