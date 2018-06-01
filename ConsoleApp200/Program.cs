using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp200
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            Thread newThread = new Thread(() =>
            {
                obj.AddMethod(234523452, 345245624);
            });
            newThread.Start();
            Console.WriteLine(newThread.ThreadState);
            Console.ReadLine();

        }

        private void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
