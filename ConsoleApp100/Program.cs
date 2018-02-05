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
            NewMethod();
            OldMethod();
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
    }
}
