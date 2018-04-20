using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp157
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Background Threads *****\n");
            Printer p = new Printer();
            Thread bgThread = new Thread(new ThreadStart(p.PrintNumbers));

            //This is now a background thread.
            bgThread.IsBackground = true;
            bgThread.Start();
            Console.ReadLine();
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

    class Printer
    {
        public void PrintNumbers()
        {
            for(int i=0;i<1000;i++)
            {
                Console.WriteLine("The i is {0},and now is {1}\n", i, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            }
        }
    }
}
