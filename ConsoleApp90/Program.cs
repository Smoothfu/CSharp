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
            Console.WriteLine("*****Working with Timer type*****\n");

            //Create the delegate for the Timer type.

            TimerCallback timerCallback = new TimerCallback(PrintTime);

            //Establish timer settings.
            Timer timer = new Timer(
                timerCallback,         //The TimerCallback delegate object.
                null,           //Any info to pass into the called method null for no info.
                10000,              //Amount of time to wait before starting in milliseconds.
                1000);          //Interval of time between calls in milliseconds


            Console.WriteLine("Hit key to termiante!\n");
            Console.ReadLine();
        }

        static void PrintTime(object obj)
        {
            Console.WriteLine("Time is :{0}\n", DateTime.Now.ToLongTimeString());
        }
    }

    [Synchronization]
    public class Printer:ContextBoundObject
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
