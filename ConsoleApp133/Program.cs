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
            var tasks = new Task[3];
            var rnd = new Random();

            for(int ctr=0;ctr<=2;ctr++)
            {
                tasks[ctr] = Task.Run(() => Thread.Sleep(rnd.Next(500, 3000)));

            }

            try
            {
                int index = Task.WaitAny(tasks);
                Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);
                Console.WriteLine("Status of all tasks:\n");
                foreach(var t in tasks)
                {
                    Console.WriteLine("Task #{0}:{1}\n", t.Id, t.Status);
                }
            }

            catch(AggregateException ae)
            {
                Console.WriteLine(ae.Message);
            }
 
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
