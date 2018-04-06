using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp151
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100, y = 200, z = 300;
            Thread addThread = new Thread(() =>
              {
                  Add(x, y, z);
              });
            addThread.Start();
            Console.ReadLine();
        }

        static void Add(int x,int y,int z)
        {
            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }
    }
}
