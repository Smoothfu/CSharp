using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp91
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = Thread.CurrentThread;
            Console.WriteLine("MainThread ManagedThreadId :{0}\n", mainThread.ManagedThreadId);

            //Queue the task.
            ThreadPool.QueueUserWorkItem(ThreadProc);
            Console.WriteLine("Main thread does some work,then sleeps.\n");
            Thread.Sleep(2000);
            Console.WriteLine("Main thread exists.\n");
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
