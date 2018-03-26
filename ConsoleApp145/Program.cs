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
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> task = new Task<int>(() => Sum(cts.Token, 10000), cts.Token);
            task.Start();

            Thread.Sleep(5000);
            cts.Cancel();

            try
            {
                //If the task got canceled,Result will throw an AggregateException.
                Console.WriteLine("The sum is :" + task.Result);
            }
            catch(AggregateException ae)
            {
                ae.Handle(x => x is OperationCanceledException);
                Console.WriteLine("Sum was cancelled!\n");
            }
            
            Console.ReadLine();
        } 

        private static int Sum(CancellationToken ct,int n)
        {
            int sum = 0;
            for(int i=0;i<n;i++)
            {
                Thread.Sleep(300);
                ct.ThrowIfCancellationRequested();
                checked
                {
                    sum += n;
                }
            }

            return sum;
        }

        
    }
}
