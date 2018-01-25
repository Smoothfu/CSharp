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
            Thread mainThread = Thread.CurrentThread;
            Console.WriteLine("This is the start of the Main thread.\n");
            //Create an object containing the information needed for the task.
            TaskInfo ti = new TaskInfo("This report displays the number {0}", 2999);

            //Queue the task and data.

            if (ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), ti))
            {
                //If you comment out the sleep,the main thread exits before the ThreadPool task has
                //a chance to run. ThreadPool uses background threads,which do not keep the application
                //running.This is a simple example of a race condition.

                //Thread.Sleep(1000);
                Console.WriteLine("\nMain thread exits.\n");
                mainThread.Join();
            }
            else
            {
                Console.WriteLine("Unable to queue ThreadPool request.\n");
            }

            Console.WriteLine("This is the end of the Main thread!\n");

            Console.ReadLine();
        }

        //This method procedure performs the task.
        static void ThreadProc(object stateInfo)
        {
            //No state object was passed to QueueUserWorkItem,so stateinfo is null.
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("ThreadProc ManagerThreadId :{0} \n", thread.ManagedThreadId);
            Console.WriteLine("Hello from the thread pool.\n");
        }
    }

    //TaskInfo holds state information for a task that will be executed by a ThreadPool thread.
    
    public class TaskInfo
    {
        
        //State information for the task.These members can be implemented as read-only properties,read/write
        //properties with validation,and so on,as required.
        public string Boilerplate;
        public int Value;

        //Public constructor provides an easy way to supply all the information needed for the task.

        public TaskInfo(string text,int number)
        {
            Console.WriteLine("This is the start of the another thread!\n");
            Boilerplate = text;
            Value = number;

            Console.WriteLine("Boilerplate is :{0}\n", Boilerplate);
            Console.WriteLine("Value is :{0}\n", Value);

            Console.WriteLine("This is the end of the constructor of another thread!\n");
        }
    }
}
