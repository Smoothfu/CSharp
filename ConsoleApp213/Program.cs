using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp213
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 43, 43, 34, 4565, 355, 4654526, 5426456, 2456234 };
            Console.WriteLine("There are {0} raw data in arr", arr.Length);
            arr.All(x =>
            {
                Console.WriteLine(x); return true;
            });

            Console.WriteLine();
            var distinctValues = arr.Distinct();
            Console.WriteLine("\nThere are {0} distinct data in arr", distinctValues.Count());
            distinctValues.ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });
            Console.ReadLine();
        }
    }
}
