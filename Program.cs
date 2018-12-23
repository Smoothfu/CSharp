using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp313
{
    delegate void MathDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            int x = 34543, y = 4256245;
            MathDel del = new MathDel(Add);
            del(x, y);
            del = new MathDel(Subtract);
            del(x, y);
            del = new MathDel(Multiply);
            del(x, y);
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}!");
        }

        static void Subtract(int x,int y)
        {
            Console.WriteLine($"{x}-{y}={x - y}");
        }

        static void Multiply(int x,int y)
        {
            Console.WriteLine($"{x}*{y}={x * y}");
        }
    }
}
