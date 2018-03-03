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
            Task<Double>[] taskArray =
            {
            Task<Double>.Factory.StartNew(()=>DoComputation(1.0)),
            Task<Double>.Factory.StartNew(()=>DoComputation(100.0)),
            Task<Double>.Factory.StartNew(()=>DoComputation(1000.0))
            };


            var results = new Double[taskArray.Length];
            double sum = 0;
            for(int i=0;i<taskArray.Length;i++)
            {
                results[i] = taskArray[i].Result;
                Console.WriteLine("{0:N1} {1}\n", results[i], i == taskArray.Length - 1 ? "=" : "+");
                sum += results[i];
            }

            Console.WriteLine("{0:N1}\n", sum);
            Console.ReadLine();
        } 

        private static Double DoComputation(double start)
        {
            Double sum = 0;
            for(var value=start; value<=start+10;value+=0.1)
            {
                sum += value;
            }
            return sum;
        }
    }
}
