using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp84
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
            Thread currThread = Thread.CurrentThread;
            Console.WriteLine("ManagedThreadId: {0}\n",currThread.ManagedThreadId);
            Console.WriteLine("IsAlive:{0}\nIsBackground:{1}\nIsThreadPoolThread:{2}\nCurrentCulture:{3}\n"+
                "CurrentUICulture:{4}\nName:{5}\nPriority:{6}\nThreadState:{7}\n",currThread.IsAlive,
                currThread.IsBackground, currThread.IsThreadPoolThread, 
                currThread.CurrentCulture.ToString(), currThread.CurrentUICulture.ToString(),
                currThread.Name,currThread.Priority, currThread.ThreadState);
        }
    }
}
