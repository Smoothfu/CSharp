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
            //Queue the task.
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));

            Console.WriteLine("Main thread does some work,then sleeps!\n");

            //If you comment out the Sleep,the main thread exists before the thread pool task runs,The thread pool uses background threads
            //which do not keep the application running.
            //Thread.Sleep(1000);

            Console.WriteLine("This is the end of the Main thread!\n");
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
