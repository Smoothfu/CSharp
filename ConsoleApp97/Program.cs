using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp97
{
    class Program
    {
        static void Main(string[] args)
        {

            //get the running thread
            Thread thread = Thread.CurrentThread;

            //set the thread name
            thread.Name = "Main Thread";

            //get the unique name
            int id = thread.ManagedThreadId;

            //get the current status
            ThreadState state = thread.ThreadState;

            //get the priority of the current thread
            ThreadPriority priority = thread.Priority;
            string msg = string.Format("Thread ID:{0}\n" +
                "Thread Name:{1}\n" +
                "Thread State:{2}\n" +
                "Thread Priority:{3}\n", id, thread.Name, state, priority);
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}
