using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp156
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads*****\n");
            Printer objPrinter = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.
            Thread[] allThreads = new Thread[10];

            for(int i=0;i<10;i++)
            {
                allThreads[i] = new Thread(new ThreadStart(objPrinter.PrintNumbers));
                allThreads[i].Name = string.Format("Worker thread #{0}\n", i);
            }

            //Now start each one.
            foreach(var thread in allThreads)
            {
                thread.Start();
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

    public class Printer
    {
        public void PrintNumbers()
        {
            for(int i=0;i<10;i++)
            {
                //Put thread to sleep for a random amount of time. 
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(5));                
                Console.WriteLine("Now i is {0} and time is {1},Id:{2}\n", i, DateTime.Now.ToString("yyyyMMdd:HHmmssfff"), Thread.CurrentThread.ManagedThreadId);
            }
            
        }
    }
}
