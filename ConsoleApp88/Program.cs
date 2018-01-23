using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp88
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Background Threads*****\n");
            Console.WriteLine("This is the start of the Main thread!\n");
            Printer p = new Printer();
            Thread bgThread = new Thread(new ThreadStart(p.PrintNumbers));

            //This is now a background thread.
            bgThread.IsBackground = true;
            bgThread.Start();


            Console.WriteLine("This is the end of Main thread!\n");
            Console.ReadLine();
        }

        static void Add(object data)
        {
            if(data is AddParams)
            {
                Console.WriteLine("Id of thread in Add(): {0}\n", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0}+{1}={2}\n", ap.X, ap.Y, ap.X + ap.Y);

                //Tell other thread we are done.
                waitHandle.Set();
            }
        }
    }

    public class AddParams
    {
        public int X { get; set; }
        public int Y { get; set; }

        public AddParams(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("This is the start of the background thread!\n");
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(i+"\n");
            }
            Console.WriteLine("This is the end of the background thread!\n");
        }
    }
}
