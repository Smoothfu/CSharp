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
            //Wait on a single task with no timeout specified.
            Task task = Task.Run(() => Thread.Sleep(2000));
            Console.WriteLine("Task Status:{0}\n", task.Status);
            try
            {
                task.Wait();
                Console.WriteLine("In try block,the task Status:{0}\n", task.Status);
            }
            catch(AggregateException ae)
            {
                Console.WriteLine(ae.Message);
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
