using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp145
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Task,defer starting it,continue with another task.
            Task<int> task = new Task<int>(x => Sum((int)x), 1000);
            task.Start();

            //Notice the use of the Result property.
            Task cwt = task.ContinueWith(x => Console.WriteLine("The sum is :" + x.Result));
            
            //for the testing only.
            cwt.Wait();
            
            Console.ReadLine();
        } 

        private static int Sum(int n)
        {
            int sum = 0;
            for(int i=0;i<n;i++)
            {
                checked { sum += n; }
            }
        return sum;
        }        
    }
}
