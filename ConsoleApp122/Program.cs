using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ConsoleApp122
{
    //A C# delegate type.
    public delegate int BinaryOp(int x, int y);

    delegate int SomeDelegate(int x);
    class Program
    {
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {

            Console.WriteLine("*****Synchronizing Threads*****\n");

            Printer p = new Printer();

            //Make 10 threads that are all pointing to the same method on the same object.
            Thread[] threads = new Thread[10];
            for(int i=0;i<10;i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}\n", i);
            }

            //Now start each one 
            foreach(Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }

        class AddParams
        {
            public int a, b;
            public AddParams(int numb1, int numb2)
            {
                a = numb1;
                b = numb2;
            }

            public static void Add(object data)
            {
                if (data is AddParams)
                {
                    Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);

                    AddParams ap = (AddParams)data;
                    Console.WriteLine("{0}+{1}={2}\n", ap.a, ap.b, ap.a + ap.b);

                    //Tell other thread we are done

                }

                waitHandler.Set();
                Console.WriteLine("The AddParam thread is over!\n");
            }
        }
    }

    public class Printer
    {
        //Lock token.
        private object threadLock = new object();
        public void PrintNumbers()
        {
            //use the lock token
            lock(threadLock)
            {
                Thread printThread = Thread.CurrentThread;
                Console.WriteLine("The printer thread id is :{0}\n", printThread.ManagedThreadId);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("i is {0} and now is :{1}\n", i, DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
                }
            }            
        }
    }

    
}
