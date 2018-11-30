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
            LINQSum();
            Console.ReadLine();
        }

        static void LINQSum()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sum = arr.Sum(x => x);
            Console.WriteLine("Sum={0}\n", sum);
            int max = arr.Max();
            Console.WriteLine("Max={0}\n", max);
            int min = arr.Min();
            Console.WriteLine(min);
        }
    }
}
