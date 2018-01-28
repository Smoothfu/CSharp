using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp95
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = Task.Run(() => {
            //    //Just loop.
            //    int ctr = 0;
            //    for (ctr=0;ctr<=100000000;ctr++)
            //    {

            //    }

            //    Console.WriteLine("Finished {0} loop iteration.\n", ctr);
            //});
            //t.Wait();

            //Task t = Task.Factory.StartNew(() =>
            //{
            //    //Just loop.
            //    int ctr = 0;
            //    for(ctr=0;ctr<=10000000;ctr++)
            //    {

            //    }
            //    Console.WriteLine("Finished {0} loop iterations.\n", ctr);
            //});

            //t.Wait();

            //Wait on a single task with no timeout specified.
            //Task taskA = Task.Run(() => Thread.Sleep(2000));
            //Console.WriteLine("taskA status: {0}\n", taskA.Status);

            //try
            //{
            //    taskA.Wait();
            //    Console.WriteLine("taskA Status: {0}\n", taskA.Status);
            //}
            //catch(AggregateException ex)
            //{
            //    Console.WriteLine("Exception in Task A.\n");
            //}

            //Wait on a single task with a timeout specified.
            Task taskA = Task.Run(() => Thread.Sleep(2000));

            try
            {
                //Wait for 1 second.
                Console.WriteLine("Sleep over!\n");
                taskA.Wait(1000);
                bool completed = taskA.IsCompleted;
                Console.WriteLine("Task A completed:{0} Status:{1}\n", completed, taskA.Status);

                if(!completed)
                {
                    Console.WriteLine("Timed out before task A completed.\n");
                }
            }

            catch(AggregateException ex)
            {
                Console.WriteLine("Exception in taskA.\n");
            }
            Console.ReadLine();
        }
    }
}
