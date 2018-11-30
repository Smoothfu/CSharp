using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp294
{
    class Program
    {
        static void Main(string[] args)
        {
            PartitionOperators();
            Console.ReadLine();
        }

        static void PartitionOperators()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var biggerthan5 = arr.Skip(5);
            foreach(int i in biggerthan5)
            {
                Console.WriteLine(i);
            }

        }

        static void LINQQuantifierOperator()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool AllBiggerThan5 = arr.All(x => x > 5);
            Console.WriteLine("AllBiggerthan5={0}\n", AllBiggerThan5);
            bool AnyBiggerThan5 = arr.Any(x => x > 5);
            Console.WriteLine("AnyBiggerThan5={0}\n", AnyBiggerThan5);
            bool Contain10 = arr.Contains(10);
            Console.WriteLine("Contain10={0}\n", Contain10);
        }
        static void LINQSum()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sum = arr.Sum(x => x);
            Console.WriteLine("Sum={0}\n", sum);
            int max = arr.Max();
            Console.WriteLine("Max={0}\n", max);
            int min = arr.Min();
            Console.WriteLine("Min={0}\n",min);
            double avg = arr.Average();
            Console.WriteLine("Avg={0}\n",avg);
        }
    }
}
