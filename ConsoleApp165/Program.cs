using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp165
{
    class Program
    {
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads*****\n");

            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.
            Thread[] allThreads = new Thread[10];

            for(int i=0;i<10;i++)
            {
                allThreads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                allThreads[i].Name = string.Format("Worker thread #{0}\n", i);
            }

            //Now start each one.
            foreach(Thread thread in allThreads)
            {
                thread.Start();
            }
            Console.ReadLine();
        }


        static void Add(int x,int y)
        {
            Console.WriteLine("The Add thread Id is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            //Tell other thread we are done.
            waitHandler.Set();
        }
        static void AddMethod(object data)
        {
            var objAddParams = data as AddParams;
            if (objAddParams != null)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("{0}+{1}={2}\n", objAddParams.a, objAddParams.b, objAddParams.a + objAddParams.b);
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
        //Lock token.
        private object lockObj = new object();
        public void PrintNumbers()
        {
            //Use the lock token.
            Monitor.Enter(lockObj);
            try            
            {
                Console.WriteLine("The Thread Id of PrintNumbers is {0}\n", Thread.CurrentThread.ManagedThreadId);

                for (int i = 0; i < 10; i++)
                {
                    //Put thread to sleep for a random amount of time.
                    Random rnd = new Random();
                    Thread.Sleep( rnd.Next(5));
                    Console.Write("{0}\t", i);
                }

                Console.WriteLine("\n\n\n\n\n");
            }   
            
            finally
            {
                Monitor.Exit(lockObj);
            }
        }
    }
}
