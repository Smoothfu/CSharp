using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Child thread starts.");

                //do some work,like counting to 10
                for(int i=0;i<=10;i++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(i);
                }
                Console.WriteLine("Child Thread Completed!");
            }

            catch(ThreadAbortException ex)
            {
                Console.WriteLine("Thread Abort Execption");
            }


            finally
            {
                Console.WriteLine("Couldn't catch the thread Exception");
            }
        }
        static void Main(string[] args)
        {
            ThreadStart childRef = new ThreadStart(CallToChildThread);
            Console.WriteLine("In main:Creating the Child thread");

            Thread childThread = new Thread(childRef);
            childThread.Start();

            //Stop the main thread for some time
            Thread.Sleep(2000);

            //now abort the child
            Console.WriteLine("In Main:Aborting the Child thread");
            childThread.Abort();
            Console.ReadLine();
        }         
    }
}
