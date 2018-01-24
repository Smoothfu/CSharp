using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

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
            for (int i = 0; i < 10; i++)
            {
                threadArray[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threadArray[i].Name = string.Format("Worker thread #{0}\n", i);
            }

            //Now start each one.
            foreach (Thread thread in threadArray)
            {
                thread.Start();
            }

            Console.ReadLine();
        }
    }

    [Synchronization]
    public class Printer
    {

        public void PrintNumbers()
        {

            //Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);

            //Print out numbers
            Console.WriteLine("Your numbers:");
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(5));
                Console.Write("{0},", i);
            }
            Console.WriteLine("\n\n");
        }
    }
}
