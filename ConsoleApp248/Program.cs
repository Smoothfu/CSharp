using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp248
{
    interface IAdd
    {
       void AddMethod(int x, int y, int z);
    }
    class Program:IAdd
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The main ManagedThreadId is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Program obj = new Program();
            Thread thread = new Thread(() =>
              {
                  AddMethod(1334, 4764567);
                  obj.AddMethod(452346245, 3445346, 456345645);
              });
            thread.Start();
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("The AddMethod ManagedThreadId is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        public void AddMethod(int x, int y, int z)
        {
            Console.WriteLine("The overload AddMethod {0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }
    }
}
