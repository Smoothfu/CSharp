using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp101
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> myAction;
            myAction = r => Console.WriteLine(r);
            myAction(9);
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            for(int i=0;i<1000;i++)
            {
                Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
                Thread.Sleep(100);
                x = x + 10000;
                y = y + 10000;
            }
        }
    }
}
