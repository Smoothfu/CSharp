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
                tasks[ctr] = Task.Run(() => Thread.Sleep(100));
            }

            try
            {
                Task.WaitAll(tasks);
            }

            catch(AggregateException ae)
            {
                Console.WriteLine("One or more exceptions occured: ");
                foreach(var ex in ae.Flatten().InnerExceptions)
                {
                    Console.WriteLine(" {0}", ex.Message);
                }                
            }

            Console.WriteLine("Status of completed tasks:\n");
            foreach (var t in tasks)
            {
                Console.WriteLine(" Task #{0}:{1}", t.Id, t.Status);
            }
            Console.ReadLine();
        }
    }
}
