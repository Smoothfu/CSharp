using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp383
{
    class Program
    {
        private static AutoResetEvent firstEvent = new AutoResetEvent(true);
        private static AutoResetEvent secondEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
                "The threads wait on AutoResetEvent #1,which was created \r\n" +
                "in the signaled state,so the first thread is released.\r\n" +
                "This inputs AutoResetEvent #1 into the unsignaled state.");

            Console.ReadLine();
            for(int i=1;i<4;i++)
            {
                Thread newThread = new Thread(ThreadProc);
                newThread.Name = "Thread_" + i;
                newThread.Start();
            }

            Thread.Sleep(250);
            for(int i=0;i<2;i++)
            {
                Console.WriteLine("Press Enter to release another thread.");
                Console.ReadLine();
                firstEvent.Set();
                Thread.Sleep(250);
            }

            Console.WriteLine("\r\nAll threads are no waiting on AutoResetEvent #2.");
            for(int i=0;i<3;i++)
            {
                Console.WriteLine("Press enter to release a thread.!");
                Console.ReadLine();
                secondEvent.Set();
                Thread.Sleep(250);
            }

            Console.ReadLine();

        }

        private static void ThreadProc()
        {
            string threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} waits on AutoResetEvent #1.");
            firstEvent.WaitOne();
            Console.WriteLine($"{threadName} is released from AutoResetEvent #1.");
            Console.WriteLine($"{threadName} waits on AutoResetEvent #2.");
            secondEvent.WaitOne();
            Console.WriteLine($"{threadName} is released from AutoResetEvent #2.");
            Console.WriteLine($"{threadName} ends");
        }
    }
}
