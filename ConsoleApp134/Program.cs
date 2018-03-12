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

            //Better:Create and start the task in one operation,
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA!\n"));

            Console.WriteLine("Status: {0},\n", taskA.Status);
            //Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}.\n", Thread.CurrentThread.Name);
            taskA.Wait();
            Console.WriteLine("Status: {0},\n",taskA.Status);
            Console.ReadLine();
        }
    }
}
