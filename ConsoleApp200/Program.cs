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
        static int x = 36245645, y = 3453454;
        static void Main(string[] args)
        {
            Program obj = new Program();
            ThreadStart ts = obj.AddMethod;
            Thread thread = new Thread(ts);
            thread.Start();
            Console.WriteLine(thread.ThreadState);
            
            Console.ReadLine();

        }

        private void AddMethod()
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
