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
            Console.WriteLine("*****Adding with Thread objects*****\n");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);
            AddParams ap = new AddParams(10, 10);

            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);


            //Wait here untile you are notified.
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!\n");
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
}
