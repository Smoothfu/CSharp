using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp156
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static object interlockedObj = new object();
        private static int interval = 83;
        private static int newValue;
        static void Main(string[] args)
        {
            Printer objPrinter = new Printer();
            Thread[] allThreads = new Thread[10];
            for(int i=0;i<10;i++)
            {
                allThreads[i] = new Thread(new ThreadStart(objPrinter.PrintNumbers));
            }

            for(int j=0;j<10;j++)
            {
                allThreads[j].Start();
            }
            Console.ReadLine();
        }

        static void Add(object data)
        {
            var addObj = data as AddParams;
            if(addObj!=null)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine("{0}+{1}={2}\n", addObj.a, addObj.b, addObj.a + addObj.b);

                //Tell other thread we are done.
                waitHandle.Set();
            }
        }

        public static void AddOne()
        {
            newValue = Interlocked.Increment(ref interval);
        }

        public static void SafeAssignment()
        {
            Interlocked.Exchange(ref interval, 83);
        }


        public static void CompareAndExchange()
        {
            //If the value of interval is currently 83,change i to 99.
            Interlocked.CompareExchange(ref interval, 99, 83);
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

    //All methods of printer are now thread safe!
    [Synchronization]
    public class Printer:ContextBoundObject
    {
        //lock token.
        private object threadLock = new object();
        public void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                //Put thread to sleep for a random amount of time. 
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(3));
                Console.WriteLine("Now i is {0} and time is {1},Id:{2}\n", i, DateTime.Now.ToString("yyyyMMdd:HHmmssfff"), Thread.CurrentThread.ManagedThreadId);
            }
        }     
    }
}
