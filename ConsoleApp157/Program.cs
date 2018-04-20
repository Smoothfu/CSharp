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
            Console.WriteLine("*****Adding with Thread objects*****\n");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);

            //Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(10, 10);
            Thread thread = new Thread(new ParameterizedThreadStart(Add));
            thread.Start(ap);

            //Wait here until you are notified.
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
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
}
