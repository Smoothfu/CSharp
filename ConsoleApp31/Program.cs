using System;
using System.Collections.Generic;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibonacciNumbers = new List<int> { 1, 1 };
            var prev = fibonacciNumbers[fibonacciNumbers.Count - 1];
            var prev2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

            fibonacciNumbers.Add(prev + prev2);

            foreach(var item in fibonacciNumbers)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
