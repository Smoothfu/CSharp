using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp108
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the task object by using an Action(of object) to pass in the loop counter.This produces an unexpected result.

            Task[] taskArray = new Task[10];
            for(int i=0;i<taskArray.Length;i++)
            {
                taskArray[i] = Task.Factory.StartNew((object obj) =>
                  {
                      var data = new CustomData() { Name = i.ToString(), CreationTime = DateTime.Now.Ticks };
                      data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                      Console.WriteLine("Task #{0} created at {1} on thread #{2}.\n", data.Name, data.CreationTime, data.ThreadNum);
                  },i);
            }

            Task.WaitAll(taskArray);
            Console.ReadLine();
        }

        private static Double DoComputation(Double start)
        {
            Double sum = 0;
            for(var value=start;value<=start+100000;value+=0.1)
            {
                sum += value;
            }
            return sum;
        }
    }

    class CustomData
    {
        public long CreationTime;
        public string Name;
        public int ThreadNum;
    }
}
