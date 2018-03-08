using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp127
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = Thread.CurrentThread;
            Console.WriteLine("The main thread ManagedThreadId:{0}\n", mainThread.ManagedThreadId);

            Thread newThread = new Thread(() =>
              {                  
                  AddMethod(10000, 10000000, 1000000000);
              });
            newThread.Start();
            Console.ReadLine();
        }

        static void AddMethod(int x,int y,int z)
        {
            Thread addThread = Thread.CurrentThread;
            Console.WriteLine("The addThread's ManagedThreadId :{0}\n", addThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
            Console.WriteLine();
        }
    }
}
