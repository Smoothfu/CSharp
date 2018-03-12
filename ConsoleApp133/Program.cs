using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp133
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Action<object> action = (object obj) =>
              {
                  Console.WriteLine("Task={0},obj={1},Thread={2}\n", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);

              };

            //Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            //Construct a started task.
            Task t2 = Task.Factory.StartNew(action, "beta");

            //Block the main thread to demonstrate that t2 is executing.
            t2.Wait();

            //Launch t1
            t1.Start();
            Console.WriteLine("t1 has been launched.(Main Thread={0})\n", Thread.CurrentThread.ManagedThreadId);

            //wait for the task to finish.
            t1.Wait();

            //construct a started task using Task.Run.

            string taskData = "delta";

            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Task={0},Obj={1},Thread={2}\n", Task.CurrentId, taskData, Thread.CurrentThread.ManagedThreadId);
            });

            //wait for the task to finish
            t3.Wait();

            //Construct an unstarted task.
            Task t4 = new Task(action, "gamma");


            //Run it synchronously.
            t4.RunSynchronously();
            t4.Wait();
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
