using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp127
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart childRef = new ThreadStart(CallToChildThread);
            Console.WriteLine("In main:Creating the child thread!\n");

            Thread childThread = new Thread(childRef);
            childThread.Start();

            Console.WriteLine("Main method before sleep is :{0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
            //stop the main thread for some time.
            Thread.Sleep(2000);
            Console.WriteLine("Main method after sleep is :{0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));

            //now abort the child.
            Console.WriteLine("In Main:Aborting the Child thread!\n");
            childThread.Abort();

            Console.ReadLine();
        }

        static void AddMethod(int x,int y,int z)
        {
            Thread addThread = Thread.CurrentThread;
            Console.WriteLine("The addThread's ManagedThreadId :{0}\n", addThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
            Console.WriteLine();
        }

        static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Child thread starts!\n");                

                //do some work,like counting to 10.
                for(int counter=0;counter<=10;counter++)
                {
                    Console.WriteLine("Before sleep is :{0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
                    Thread.Sleep(500);
                    Console.WriteLine("The counter is {0} and after sleep is {1}\n", counter, DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
                }
                Console.WriteLine("Child Thread Completed!\n");                
                 
            }
            catch(ThreadAbortException ex)
            {
                Console.WriteLine("Thread Abort Exception!\n");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception!\n");
            }
            
        }
    }
}
