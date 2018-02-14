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

            //Define and run the task.
            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA!\n"));

            //Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'", Thread.CurrentThread.Name);
            taskA.Wait();
            Console.ReadLine();
        }
    }
}
