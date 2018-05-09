using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp166
{
    class Program
    {
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Adding with Thread objects*****\n");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);
            AddParams objAddParams = new AddParams(10, 10);
            Thread thread = new Thread(new ParameterizedThreadStart(Add));
            thread.Start(objAddParams);


            //Wait here until you are notified.
            waitHandler.WaitOne();
            Console.WriteLine("Other thread is safe!\n");
            Console.ReadLine();
        }

        static void Add(object data)
        {
            var obj = data as AddParams;
            if(obj!=null)
            {
                Console.WriteLine("ID of thread in Add() :{0}\n", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("{0}+{1}={2}\n", obj.a, obj.b, obj.a + obj.b);

                //Tell other thread we are done,
                waitHandler.Set();
            }
        }
    }

    class AddParams
    {
        public int a, b;
        public AddParams(int num1,int num2)
        {
            a = num1;
            b = num2;
        }
    }
}
