using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
         
        static void Main(string[] args)
        {
            Console.WriteLine("The main thread started!");
            Thread thread = new Thread(Go);
            thread.Start();
            Console.WriteLine("Thread state: " + thread.ThreadState);

            thread.Suspend();
            Console.WriteLine("Thread State after Suspend: " + thread.ThreadState);

            thread.Resume();
            Console.WriteLine("Thread state after Resume: " + thread.ThreadState);
            

            Console.WriteLine("Thread has ended");


            Console.ReadLine();
        }

        static void Go()
        {
            for(int i=0;i<1000;i++)
            {
                Console.Write("Y");
            }
        }

       

    }
}
