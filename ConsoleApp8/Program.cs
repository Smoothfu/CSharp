using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10, y = 20;
            Console.WriteLine("Before swap: x={0},y={1}", x, y);
            Swap(ref x,ref  y);
            Console.WriteLine("After swap: x={0},y={1}", x, y);
            Console.ReadLine();
        }

        static void Swap(ref int x,ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}
