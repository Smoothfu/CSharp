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
            //Wait on a single task with no timeout specified.
            Task taskA = Task.Run(() => Thread.Sleep(2000));

            try
            {
                taskA.Wait(1000);
                bool isCompleted = taskA.IsCompleted;
                Console.WriteLine("Task A completed:{0},Status:{1}\n", isCompleted, taskA.Status);

                if(!isCompleted)
                {
                    Console.WriteLine("Timed out before task A completed!\n");
                }
            }

            catch(AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
