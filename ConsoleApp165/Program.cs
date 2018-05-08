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
            Console.WriteLine("*****Adding with Thread objects*****\n");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);

            Thread thread = new Thread(() =>
              {
                  Add(10,10);
              });

           
            thread.Start();

            //Wait here until you are notified.
            waitHandler.WaitOne();
            Console.WriteLine("Other thread is done!\n");
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
}
