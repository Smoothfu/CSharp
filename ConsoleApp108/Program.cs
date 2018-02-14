using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Versioning;
using System.Globalization;

[assembly: TargetFramework(".NETFramework,Version=v4.6")]
namespace ConsoleApp108
{
   
    class Program
    {
        static void Main(string[] args)
        {
            var displayData = Task.Factory.StartNew(() =>
            {
                Random rnd = new Random();
                int[] values = new int[100];
                for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
                {
                    values[ctr] = rnd.Next();
                }
                return values;
            }).
            ContinueWith((x) =>
            {
                int n = x.Result.Length;
                long sum = 0;
                double mean;

                for (int ctr = 0; ctr <= x.Result.GetUpperBound(0); ctr++)
                {
                    sum += x.Result[ctr];
                }

                mean = sum / (double)n;
                return Tuple.Create(n, sum, mean);
            }).
            ContinueWith((x) =>
            {
                return string.Format("N={0:N0},Total={1:N0},Mean={2:N2}\n", x.Result.Item1, x.Result.Item2, x.Result.Item3);

            });
            Console.WriteLine(displayData.Result);
           
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
