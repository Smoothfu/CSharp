using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts; 

namespace ConsoleApp157
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Working with Timer type*****\n");

            //Create the delegate for the Timer type.
            TimerCallback timerCallback = new TimerCallback(PrintTime);

            //Establish timer settings.
            Timer timer = new Timer(timerCallback, null, 0, 1000);
            Console.WriteLine("Hit key to terminate!\n");
           
            Console.ReadLine();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Time is :{0}\n", DateTime.Now.ToLongTimeString());
        }

        static void Add(object data)
        {
            var ap = data as AddParams;
            if(ap!=null)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("{0}+{1}={2}\n", ap.a, ap.b, ap.a + ap.b);
            }

            //Tell other thread we are done.
            waitHandle.Set();
        }
    }

    class AddParams
    {
        public int a, b;

        public AddParams(int numb1,int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }

    [Synchronization]
    class Printer:ContextBoundObject
    {
        public void PrintNumbers()
        {
            for(int i=0;i<10;i++)
            {
                //Put thread to sleep for a random amount of time.
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(5));
                Console.WriteLine("The i is {0},and now is {1}\n", i, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            }
        }
    }
}
