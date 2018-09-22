using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp262
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 91935, y = 35647;
            AddMethod(x, y);
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
