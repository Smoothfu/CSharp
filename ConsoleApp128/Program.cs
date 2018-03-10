using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp128
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads*****\n");
            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.
            Thread[] threads = new Thread[10];
            for(int i=0;i<10;i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }

            //Now start each one.
            foreach(Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }

        static void Add(object data)
        {
            var addObj = data as AddParams;
            if(addObj==null)
            {
                return;
            }

            if(addObj is AddParams)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)addObj;
                Console.WriteLine("{0}+{1}={2}\n", ap.a, ap.b, ap.a + ap.b); 
            }
        }
    }

    public class Printer
    {
        //the thread lock token;
        private static object lockToken = new object();
        public void PrintNumbers()
        {
            Monitor.Enter(lockToken);
            try
            {
                //Display Thread info.
                Console.WriteLine("\n\n\n->{0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);

                //Print out numbers.
                Console.WriteLine("Your numbers: ");

                for (int i = 0; i < 10; i++)
                {
                    //Put thread to sleep for a random amount of time.
                    Console.WriteLine("i is {0},now is :{1}", i, DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
                }
                Console.WriteLine();
            }           

            finally 
            {
                Monitor.Exit(lockToken);
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
}
