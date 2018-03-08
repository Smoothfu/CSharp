using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp126
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100, y = 10000, z = 10000000;
            Thread thread = new Thread(() =>
              {
                  AddMethod(x, y, z);
              });
            thread.Start();
            Console.ReadLine();
        }

        static void AddMethod(int x,int y,int z)
        {
            Thread addThread = Thread.CurrentThread;
            Console.WriteLine("Thread Id:{0}\n", addThread.ManagedThreadId);

            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }
    }
}
