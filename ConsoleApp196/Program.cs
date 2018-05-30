using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp196
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
            Thread ct = Thread.CurrentThread;
            Console.WriteLine(ct.ManagedThreadId);
            Console.WriteLine(ct.ApartmentState);
            Console.WriteLine(ct.CurrentCulture);
            Console.WriteLine(ct.CurrentUICulture);
            Console.WriteLine(ct.IsAlive);
            Console.WriteLine(ct.IsBackground);
            Console.WriteLine(ct.IsThreadPoolThread);
            Console.WriteLine(ct.Name);
            Console.WriteLine(ct.Priority);
            Console.WriteLine(ct.ThreadState);             
        }
    }
}
