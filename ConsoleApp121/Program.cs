using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp121
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";

            //Create a task and supply a user delegate by using a lambda expression.
            Task taskA = new Task(() => Console.WriteLine("Hello from taskA!\n"));

            //start the task.
            taskA.Start();

            //output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'\n", Thread.CurrentThread.Name);
            taskA.Wait();
            Console.ReadLine();
        } 
    }
}
