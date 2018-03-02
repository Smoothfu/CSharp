using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp120
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Task[20];
            var rand = new Random();
            for(int ctr=0;ctr<20;ctr++)
            {
                tasks[ctr] = Task.Run(() => Thread.Sleep(rand.Next(500, 3000)));
            }

            try
            {
                int index = Task.WaitAny(tasks);
                Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);
                Console.WriteLine("Status of all tasks:\n");

                foreach(var t in tasks)
                {
                    Console.WriteLine("Task #{0}:{1}", t.Id, t.Status);
                }

            }

            catch(AggregateException ex)
            {
                Console.WriteLine("An exception occured!\n");
            }
            Console.ReadLine();
        }
    }
}
