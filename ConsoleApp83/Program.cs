using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp83
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
            //Get the method currently executing this method.
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine("ManagedThreadId: {0}\n",currentThread.ManagedThreadId);
        }
    }
}
