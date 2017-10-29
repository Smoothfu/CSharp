using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static bool done = false;
        static readonly object locker = new object();

        static void Main(string[] args)
        {
            new Thread(Go).Start();
            Go();
            Console.ReadLine();
        }

        static void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Done");
                    done = true;
                }
            }
        }

    }
}
