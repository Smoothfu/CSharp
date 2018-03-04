using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp122
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractExecutingThread();
            Console.ReadLine();
        }

        static void ExtractExecutingThread()
        {
            //Get the thread currently executing this method.

            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine("Id: {0}\n", currentThread.ManagedThreadId);
            Console.WriteLine("CurrentCulture :{0}\n",currentThread.CurrentCulture);
            Console.WriteLine("CurrentUICulture:{0}\n", currentThread.CurrentUICulture);
            Console.WriteLine("IsAlive:{0}\n",currentThread.IsAlive);
            Console.WriteLine("IsBackground:{0}\n",currentThread.IsBackground);
            Console.WriteLine("IsThreadPoolThread: {0}\n",currentThread.IsThreadPoolThread);
            Console.WriteLine("Name: {0}\n",currentThread.Name);
            Console.WriteLine("Priority:{0}\n",currentThread.Priority);
            Console.WriteLine("ThreadState:{0}\n", currentThread.ThreadState);
        }
    }
}
