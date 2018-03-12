using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp133
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1000000, y = 23207890;
            Task task = new Task(() =>
              {
                  Add(x, y);

              });

            Console.WriteLine("Task Status:{0}\n", task.Status);
            task.Start();
            Console.WriteLine("Task Status:{0}\n", task.Status);
            task.Wait();
            Console.WriteLine("Task Status:{0}\n", task.Status);
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
