using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp108
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "MainThread";

            //Better:Create and start the task in one operation.
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA!\n"));

            //Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'", Thread.CurrentThread.Name);
            taskA.Wait();
            Console.ReadLine();
        }
    }
}
