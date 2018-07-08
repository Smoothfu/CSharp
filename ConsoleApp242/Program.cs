using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp242
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The managedThreadIs is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Thread thread = new Thread(() =>
              {
                  AddMethod(235434, 456345645);
              });
            thread.Start();
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("The managedthreadIs in AddMethod is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }
    }
}
