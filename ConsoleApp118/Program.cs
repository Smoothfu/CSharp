using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp118
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            //Wait on a single task with no timeout specified.
            Task taskA = Task.Run(() => Thread.Sleep(2000));

            Console.WriteLine("taskA Status:{0} \n", taskA.Status);

            try
            {
                taskA.Wait();
                Console.WriteLine("taskA Status:{0}\n", taskA.Status);
            }

            catch(AggregateException)
            {
                Console.WriteLine("Exception in taskA!\n");
            }

            Console.ReadLine();
        }
    }
}
