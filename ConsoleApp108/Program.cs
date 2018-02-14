﻿using System;
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
            Thread.CurrentThread.Name = "Main";

            //Create a task and supply a user delegate by using a lambda expression.
            Task taskA = new Task(() => Console.WriteLine("Hello from taskA.!\n"));

            //start the task.
            taskA.Start();

            //Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'", Thread.CurrentThread.Name);
            Console.ReadLine();
            taskA.Wait();
            Console.ReadLine();
        }
    }
}
