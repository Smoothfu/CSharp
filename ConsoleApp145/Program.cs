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
            Task<int[]> parent = new Task<int[]>(() =>
              {
                //Create an array for the results

                var results = new int[3];

                //This tasks create and star 3 child tasks.
                new Task(() => results[0] = Sum(1000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = Sum(2000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = Sum(3000), TaskCreationOptions.AttachedToParent).Start();

                //Returns a reference to the array  even though the elements may not be initialized yet
                return results;
              });

            //When the parent and its children have run to completion,display the results.
            var cwt = parent.ContinueWith(x => Array.ForEach(x.Result, Console.WriteLine));

            //Start the parent Task so it can start its children.
            parent.Start();

            //For testing purposes.
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
