using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp102
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1000, y = 1000;
            Thread thread = new Thread(new ThreadStart(new Action(() => {
                Add(x, y);
            })));

            thread.Start();
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            for(int i=0;i<10000;i++)
            {
                Console.WriteLine("{0}+{1}={2}", x, y, x + y);
                x = x + 10000;
                y = y + 10000;
            }
            
        }
    }
}
