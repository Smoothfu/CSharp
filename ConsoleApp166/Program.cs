using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp166
{
    class Program
    {
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Working with Timer type*****\n");

            //Create the delegate for the Timer type.
            TimerCallback timeCB = new TimerCallback(PrintTime);

            //Establish timer settings.
            Timer timer = new Timer(timeCB, null, 0, 1000);
            Console.WriteLine("Hit key to termimate...\n");
           
            Console.ReadLine();
        }   
        
        static void PrintTime(Object state)
        {
            Console.WriteLine("Time is {0}\n", DateTime.Now.ToString());
        }
    }
     
    
}
