using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp99
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
            //Get the thread currently.
            //executing this method.
            Thread currThread = Thread.CurrentThread;
            Console.WriteLine("ManagedThreadId: {0}\n", currThread.ManagedThreadId);
            Console.WriteLine("Name: {0}\n",currThread.Name);
            Console.WriteLine("IsThreadPoolThread:{0}\n", currThread.IsThreadPoolThread);
            Console.WriteLine("IsBackground:{0}\n", currThread.IsBackground);
            Console.WriteLine("CurrentCulture:{0}\n", currThread.CurrentCulture);
            Console.WriteLine("CurrentUICulture: {0}\n",currThread.CurrentUICulture);  
        }


    }
}
