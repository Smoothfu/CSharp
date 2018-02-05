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
            int x = 1000, y = 1000;

            Thread thread = new Thread(() =>
              {
                  Add(x, y);
              });
            
            //Start the thread.
            thread.Start();

            


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

        [Obsolete("Don't use OldMethod,use NewMethod instead",true)]
        static void OldMethod()
        {
            Console.WriteLine("It is the old method!\n");
        }

        static void NewMethod()
        {
            Console.WriteLine("It is the new method!\n");
        }

        static void Add(int x,int y)
        {
            for(int i=0;i<1000;i++)
            {
                Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
                x = x + 1000;
                y = y + 1000;
                Thread.Sleep(500);
            }
        }
    }
}
