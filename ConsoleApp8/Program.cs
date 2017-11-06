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

            string str1 = "Fred", str2 = "ST";
            Console.WriteLine("Before swap:str1={0},str2={1}", str1, str2);
            Swap(ref str1, ref str2);
            Console.WriteLine("After swap:str1={0},str2={1}", str1, str2);
            Console.ReadLine();
        }

        static void Swap<T>(ref T val1,ref T val2)
        {
            T temp = val1;
            val1 = val2;
            val2 = temp;
        }
    }
}
