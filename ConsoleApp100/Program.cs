using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp100
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart childRef = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main:Creating the Child thread.!\n");

            Thread childThread = new Thread(childRef);

            childThread.Start();
            Console.ReadLine();
        }

        //public static void CallToChildThread()
        //{
        //    Console.WriteLine("Child thread starts!\n");
        //}

        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts!\n");

            //the thread is paused for 5000 milliseconds.
            int sleepFor = 5000;

            Console.WriteLine("Child Thread Paused for {0} seconds.\n", sleepFor / 1000);
            Thread.Sleep(sleepFor);
            Console.WriteLine("Child thread resumes!\n");
        }
    }
}
