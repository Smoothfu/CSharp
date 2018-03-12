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

            //Wait on a single task with a timeout specified.
            Task task = Task.Run(() => Thread.Sleep(2000));
            try
            {
                task.Wait(1000);
                bool isCompleted = task.IsCompleted;
                Console.WriteLine("task completed:{0},status:{1}\n", isCompleted, task.Status);
                if(!isCompleted)
                {
                    Console.WriteLine("Timed out before task A completed!\n");
                }
            }

            catch(AggregateException ae)
            {
                Console.WriteLine("Exception in task!\n");
            }
            Console.WriteLine("Task Status:{0}\n", task.Status);
            //task.Start();
            //Console.WriteLine("Task Status:{0}\n", task.Status);
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
