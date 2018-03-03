using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Runtime.Versioning;

[assembly:TargetFramework(".NETFramework,Version=v4.7")]

namespace ConsoleApp121
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
              }).ContinueWith((x) =>
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
              }).ContinueWith((x) =>
              {
                  return string.Format("N={0:N0},Total={1:N0},Mean={2:N2}", x.Result.Item1, x.Result.Item2, x.Result.Item3);
              });
            Console.WriteLine(displayData.Result);     

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
