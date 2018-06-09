using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace ConsoleApp216
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads*****\n");
            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.
            Thread[] allThreads = new Thread[10];

            for(int i=0;i<10;i++)
            {
                allThreads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                allThreads[i].Name = string.Format("Worker thread #{0}", i);
            }

            //Now start each one.
            foreach(Thread t in allThreads)
            {
                t.Start();
            }
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        static void Add(object data)
        {
            var addParam = data as AddParams;
            if(addParam!=null)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);

                AddParams ap = (AddParams)data;
                Console.WriteLine("{0}+{1}={2}\n", ap.a, ap.b, ap.a + ap.b);
            }


            //Tell other thread we are done.
            waitHandle.Set();
        }

    }

    public class Printer
    {
        //Lock token.
        private object threadLock = new object();
        public void PrintNumbers()
        {
            lock(threadLock)
            {
                //Display Thread Info
                Console.WriteLine("->{0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);

                //Print out numbers
                Console.Write("Your numbers:\n");
                for (int i = 0; i < 10; i++)
                {
                    //Put thread to sleep for a random amount of time.
                    Random rnd = new Random();
                    Thread.Sleep(1000 * rnd.Next(5));
                    Console.Write("{0}\t", i);
                }
            }
           
            Console.WriteLine();

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
}
