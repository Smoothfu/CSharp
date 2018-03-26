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
            Task<string> strTask = new Task<string>(x => PrintMessage((string)x), "The world is wonderful and fair!");
            strTask.Start();
            strTask.Wait();
            Console.WriteLine("Status: {0}\n", strTask.Status);

            Console.WriteLine("The result is :{0}\n", strTask.Result);
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

        private static string PrintMessage(string msg)
        {
            string str = string.Format("The msg is {0},and now is {1}\n", msg, DateTime.Now.ToString("yyyyMMddhhmmssfff"));
            return str;
        }
    }
}
