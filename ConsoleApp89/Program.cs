using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp89
{
    class Program
    {
        //Be sure to import the System.Threading namespace.
        static void Main(string[] args)
        {
            Console.WriteLine("*****Primary Thread stats*****\n");

            //Obtain and name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            //Show details of hosting AppDomain/Context.
            Console.WriteLine("Name of current AppDomain: {0}\n", Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current Context: {0}\n", Thread.CurrentContext.ContextID);

            //Print out some stats about this thread.
            Console.WriteLine("Thread Name:{0}\n", primaryThread.Name);
            Console.WriteLine("Has thread started?:{0}\n", primaryThread.IsAlive);
            Console.WriteLine("Priority Level:{0}\n", primaryThread.Priority);
            Console.WriteLine("Thread State:{0}\n", primaryThread.ThreadState);
            Console.ReadLine();
        }
    }
}
