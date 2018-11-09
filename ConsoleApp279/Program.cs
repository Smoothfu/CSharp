using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Threading;

namespace ConsoleApp279
{
    class Program
    {
        delegate void AddDel(int x, int y);
        delegate void StringDel(string str);
        static void Main(string[] args)
        {
            AddDel del = delegate (int x, int y)
            {
                Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            };

            del(100, 100000000);
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
