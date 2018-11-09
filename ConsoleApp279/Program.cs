using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Threading;

namespace ConsoleApp279
{
    class Program
    { 
        delegate void StringDel(string str);
        static void Main(string[] args)
        {
            Console.WriteLine("The main main thread ManagedThreadId is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });

            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
