using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Add(int x,int y,int z)
        {
            Console.WriteLine("{0}+{1}+{2}={3}", x, y, z, x + y + z);
        }

        static void Subtract(int x,int y,int z)
        {
            Console.WriteLine("{0}-{1}-{2}={3}", x, y, z, x - y - z);
        }

        static void Multiply(int x,int y,int z,int w)
        {
            Console.WriteLine("{0}*{1}*{2}*{3}={4}", x, y, z, w, x * y * z * w);
        }
        static void Main(string[] args)
        {
            int x = 10, y = 20, z = 30, w = 40;
            Thread thread = new Thread(() =>
              {
                  Add(x, y, z);
                  Subtract(x, y, z);
                  Multiply(x, y, z, w);
              });

            thread.Start();

            Console.WriteLine("Thread State: " + thread.ThreadState);

            thread.Join();
            if(thread.ThreadState==ThreadState.Stopped)
            {
                Console.WriteLine("ThreadState: "+thread.ThreadState);
            }
            Console.ReadLine();
        }
    }
}
