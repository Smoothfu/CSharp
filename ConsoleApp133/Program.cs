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
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            var tasks = new Task[10]; 

            for(int ctr=0;ctr<10;ctr++)
            {
                tasks[ctr] = Task.Run(() => Thread.Sleep(rnd.Next(500, 3000)));
            }

            try
            {
                Task.WaitAll(tasks);
            }

            catch(AggregateException ae)
            {
                Console.WriteLine("One or more exceptions occured:\n");
                foreach(var ex in ae.Flatten().InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
 
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
