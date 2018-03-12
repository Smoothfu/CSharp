using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp134
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";

            //Define and run the task.
            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA!\n"));
            Console.WriteLine("Status: {0},\n", taskA.Status);
            //Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}.\n", Thread.CurrentThread.Name);
            taskA.Wait();
            Console.WriteLine("Status: {0},\n",taskA.Status);
            Console.ReadLine();
        }
    }
}
