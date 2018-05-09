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

            ThreadStart ts = new ThreadStart(VoidMethod);
            Thread thread = new Thread(ts);
            thread.Start();

            Console.ReadLine();
        }

        static void Add(object data)
        {
            var obj = data as AddParams;
            if(obj!=null)
            {
                Console.WriteLine("ID of thread in Add() :{0}\n", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("{0}+{1}={2}\n", obj.a, obj.b, obj.a + obj.b);

                Thread.Sleep(5000);
                //Tell other thread we are done,
                waitHandler.Set();
            }
        }

        static void AddMethod(int x,int y,int z)
        {
            Console.WriteLine("The AddMethod thread id is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }

        static void VoidMethod()
        {
            Console.WriteLine("The VoidMethod thread id is :{0}\n", Thread.CurrentThread.ManagedThreadId);
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
