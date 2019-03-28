using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp332
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Add, null);
            Console.ReadLine();
        }
        static void Add(object obj)
        {
            Console.WriteLine($"Guid:{Guid.NewGuid()}");
        }
    }
}
