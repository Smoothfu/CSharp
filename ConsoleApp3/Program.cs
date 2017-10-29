using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static void CallChildThread()
        {
            Console.WriteLine("Child thread starts!");
        }
        static void Main(string[] args)
        {
            ThreadStart childRef = new ThreadStart(CallChildThread);
            Console.WriteLine("In main:Creating the child thread.");
            Thread childThread = new Thread(childRef);
            childThread.Start();
            Console.ReadKey();
        }
    }
}
