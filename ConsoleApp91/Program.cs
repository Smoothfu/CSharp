using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp91
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> action = (object obj) =>
              {
                  Console.WriteLine("Task={0},obj={1},Thread={2}\n", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);
              };

            //Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            //Constructor a started task.
            Task t2 = Task.Factory.StartNew(action, "beta");

            //Block the main thread to demonstrate that t2 is executing.
            t2.Wait();

            //Launch t1
            t1.Start();
            Console.WriteLine("t1 has been launched.(Main Thread={0})\n", Thread.CurrentThread.ManagedThreadId);

            //wait for the task to finish.
            t1.Wait();

            //Construct a started task using Task.Run.
            string taskData = "delta";
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Task={0},obj={1},Thread={2}\n", Task.CurrentId, taskData, Thread.CurrentThread.ManagedThreadId);
            });

            //wait for the task to finish
            t3.Wait();

            //Construct an unstarted task.
            Task t4 = new Task(action, "gamma");
            //Run it synchronously.
            t4.RunSynchronously();

            //Although the task was run synchronously,it is a good practice to wait for it in the event 
            // exceptions were thrown by the task.
            t4.Wait();
            Console.ReadLine();
        }

        //This method procedure performs the task.
        static void ThreadProc(object stateInfo)
        {
            //No state object was passed to QueueUserWorkItem,so stateinfo is null.
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("ThreadProc ManagerThreadId :{0}\n", thread.ManagedThreadId);
            Console.WriteLine("Hello from the thread pool.\n");
        }
    }
}
