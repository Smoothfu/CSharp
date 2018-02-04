using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp100
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart childRef = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main:Creating the child thread!\n");
            Thread childThread = new Thread(childRef);
            childThread.Start();
            Console.ReadLine();
        }

        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts!\n");
        }
    }
}
