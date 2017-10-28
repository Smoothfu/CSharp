using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = Thread.CurrentThread;
            thread.Name = "MainThread";
            Console.WriteLine("The current thread name is " + thread.Name);
            Console.WriteLine(thread.ThreadState);
            ////Abort
            //thread.Abort();
            //Console.WriteLine("Abort :" + thread.ThreadState);
            //Console.WriteLine("IsAlive: " + thread.IsAlive);

            //
            thread.Join();
            Console.WriteLine("Join :" + thread.ThreadState);
            thread.Start();

            //
            thread.Resume();
            Console.WriteLine("Resume: " + thread.ThreadState);

            //
            thread.Suspend();
            Console.WriteLine("Suspend: " + thread.ThreadState);

            //CurrentCulture
            Console.WriteLine("CurrentCulture: " + thread.CurrentCulture);

            //CurrentUICulture
            Console.WriteLine("CurrentUICulture: " + thread.CurrentUICulture);

            //Type
            Console.WriteLine("Type: " + thread.GetType());

            //Resume
            thread.Resume();
            Console.WriteLine("Resume: " + thread.ThreadState);

            //Interrupt
            thread.Interrupt();
            Console.WriteLine("State: "+thread.ThreadState);

            //Priority
            Console.WriteLine("Priroity: " + thread.Priority);

            
            Console.ReadKey();
        }
    }
}
