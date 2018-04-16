using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp155
{
    class Program
    {
        static int x = 100000, y = 200000000;
        delegate void AddDel(ref int x, ref int y);
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                ExtractExecutingThread();
            });
            
            Console.ReadLine();
        }

        static void AddMethod(ref int x, ref  int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            x = x + 1000;
            y = y + 1000;
            Console.WriteLine("Now x is {0},y is {1}", x, y);
        }

        static void ExtractExecutingThread()
        {
            //Get the thread currently executing this method.
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine("ManagedThreadId:{0}\n",currentThread.ManagedThreadId);
            Console.WriteLine("Name:{0}\n",currentThread.Name);
            Console.WriteLine("Priority:{0}\n", currentThread.Priority);
            Console.WriteLine("ThreadState:{0}\n", currentThread.ThreadState);
            Console.WriteLine("CurrentCulture:{0}\n",currentThread.CurrentCulture);
            Console.WriteLine("CurrentUICulture:{0}\n",currentThread.CurrentUICulture);
            Console.WriteLine("IsAlive:{0}\n",currentThread.IsAlive);
            Console.WriteLine("IsBackground:{0}\n", currentThread.IsBackground);
            Console.WriteLine("IsThreadPoolThread:{0}\n", currentThread.IsThreadPoolThread); 
        }
    }
}
