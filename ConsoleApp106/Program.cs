using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp106
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Primary Thread stats*****\n");

            int x = 10000, y = 10000;
            Thread thread = new Thread(new ThreadStart(new Action(() =>
              {
                  Add(x, y);
              })));
            thread.Start();
            Console.WriteLine("The thread state: {0}\n", thread.ThreadState);
            //Obtain and name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            //Show details of hosting AppDomain/Context.
            Console.WriteLine("Name of current AppDomain:{0}\n", Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current Context:{0}\n", Thread.CurrentContext.ContextID);

            //Print out some stats about this thread.
            Console.WriteLine("Thread Name:{0}\n", primaryThread.Name);

            Console.WriteLine("Has thread started?:{0}\n", primaryThread.IsAlive);

            Console.WriteLine("Priority Level:{0}\n", primaryThread.Priority);

            Console.WriteLine("Thread State:{0}\n", primaryThread.ThreadState);

            Console.WriteLine("This is the end of the main thread!\n");
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Thread addThread = Thread.CurrentThread;
            addThread.Name = "AddThread";
            Console.WriteLine("The Add thread Id:{0}\n", Thread.CurrentThread.ManagedThreadId);
            TimeSpan ts = new TimeSpan(0, 0,0, 0,10);
            for(int i=0;i<100;i++)
            {
                Console.WriteLine("{0}+{1}={2}.Now is  {3}\n", x, y, x + y, DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
                x = x + 1000;
                y = y + 1000;
                Thread.Sleep(ts);
            }
        }
    }
}
