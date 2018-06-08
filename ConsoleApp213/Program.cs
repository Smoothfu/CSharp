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
            string str = "The world is fair and everything depend on myself!";
            ConvertStringToCharArray(str);
            Console.ReadLine();
        }

        static void GetDistinctValues(int[] arr)
        {
            if (arr == null || !arr.Any())
            {
                return;
            }

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
        }

        static void ConvertStringToCharArray(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            char[] charArr = str.ToCharArray();

            Console.WriteLine("There are {0} characters in the raw string\n\n", charArr.Length);
            if (charArr == null || !charArr.Any())
            {
                return;
            }
            charArr.All(x =>
            {
                Console.Write(x);
                return true;
            });

            var distinctValues = charArr.Distinct();
            Console.WriteLine("\n\nThere are {0} distinct values.\n\n\n", distinctValues.Count());
            distinctValues.All(x =>
            {
                Console.Write(x);
                return true;
            });
        }

    }
}

