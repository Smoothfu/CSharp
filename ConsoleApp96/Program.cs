using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp96
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread lowThread = new Thread(new ThreadStart(LowPriorityMethod));
            lowThread.Priority = ThreadPriority.Lowest;
            lowThread.Start();

            Thread highThread = new Thread(new ThreadStart(HighestPriorityMethod));
            highThread.Priority = ThreadPriority.Highest;
            highThread.Start();
            Console.ReadLine();
        }

        static void LowPriorityMethod()
        {
            for(int i=0;i<100;i++)
            {
                Console.WriteLine("The thread with lowest priority!");
            }            
        }

        static void HighestPriorityMethod()
        {
            for(int i=0;i<100;i++)
            {
                Console.WriteLine("The thread with highest priority");
            }
            
        }
    }
}
