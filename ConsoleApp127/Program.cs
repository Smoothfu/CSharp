using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp127
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart childRef = new ThreadStart(CallToChildThread);
            Console.WriteLine("In main:Creating the child thread!\n");
            Thread childThread = new Thread(childRef);
            childThread.Start();
            Console.ReadLine();
        }

        static void AddMethod(int x,int y,int z)
        {
            Thread addThread = Thread.CurrentThread;
            Console.WriteLine("The addThread's ManagedThreadId :{0}\n", addThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
            Console.WriteLine();
        }

        static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts!\n");
        }
    }
}
