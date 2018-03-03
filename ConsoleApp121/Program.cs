using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp121
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the task object by using an Action (Of object) to pass in the loop counter, this produces an unexpected result.
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                  {
                      CustomData data = obj as CustomData;
                      if(data==null)
                      {
                          return;
                      }
                      data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                  },
                  new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });

                taskArray[i].Wait();
                Console.WriteLine("The {0} task has been completed!\n", taskArray[i].Id);
            }

            Task.WaitAll(taskArray);

            foreach(var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if(data!=null)
                {
                    Console.WriteLine("Task #{0} created at {1},ran on thread #{2}\n", data.Name, data.CreationTime, data.ThreadNum);
                }
            }

            Task.WaitAll(taskArray);

            Console.ReadLine();
        } 

        
    }

    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }
}
