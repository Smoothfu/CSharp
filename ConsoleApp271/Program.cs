using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp271.MathServiceReference;

namespace ConsoleApp271
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10000, y = 242236;
            MathServiceReference.MathClient math = new ConsoleApp271.MathServiceReference.MathClient();
            int sum = math.Sum(x, y);
            Console.WriteLine("{0}+{1}={2}\n", x, y, sum);
            int subtract = math.Subtract(x, y);
            Console.WriteLine("{0}-{1}={2}\n", x, y, subtract);
            int multiply = math.Multiply(x, y);
            Console.WriteLine("{0}*{1}={2}\n", x, y, multiply);
            int divide = math.Divide(x, y);
            Console.WriteLine("{0}/{1}={2}\n", x, y, divide);
            Console.ReadLine();

        }
    }
}
