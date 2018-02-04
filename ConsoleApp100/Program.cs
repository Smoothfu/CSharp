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
            Console.WriteLine("In Main:Creating the Child thread!\n");

            Thread childThread = new Thread(childRef);
            childThread.Start();

            //stop the main thread for some time.
            Thread.Sleep(2000);

            //now abort the child.
            Console.WriteLine("In Main:Aborting the Child thread!\n");
            childThread.Abort();
            Console.ReadLine();
        }

        //public static void CallToChildThread()
        //{
        //    Console.WriteLine("Child thread starts!\n");
        //}

        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Child thread starts!\n");

                //do some work, like counting to 10.
                for(int counter=0;counter<10;counter++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(counter);
                }
            }

            catch(ThreadAbortException ex)
            {
                Console.WriteLine("Thread Abort Exception!\n");
            }

            finally
            {
                Console.WriteLine("Could not catch the Thread Exception!\n");
            }
        }
    }
}
