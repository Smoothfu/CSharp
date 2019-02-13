using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp324
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionTSample();
            Console.ReadLine();
        }

        static void ActionTSample()
        {
            Action<int> intAction = x => { Console.WriteLine($"The cubic of {x} is {x * x * x}"); };
            intAction(1000);

            Action<string> stringAction = str =>
            {
                Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}, str is {str}");
            };

            stringAction("Work hard!");
        }
        static void ThreadStartSample()
        {
            Console.WriteLine("Main thread:Start a second thread.");
            Thread thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Main thread:Do some work.");
                Thread.Sleep(0);
            }

            Console.WriteLine("Main thread:Call Join(),to wait until ThreadProc ends.");
            thread.Join();
            Console.WriteLine("Main thread:ThreadProc.Join has returned.");
        }
        public static void ThreadProc()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine($"ThreadProc:{i}");
                Thread.Sleep(0);
            }
        }
    }
}
