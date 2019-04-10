using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp337
{
    class Program
    {
        static void Main(string[] args)
        {
            Add(0);
            Add(1, 2);
            Add(1, 2, 3);
            Add(1, 2, 3, 4); 
            Console.ReadLine();
        }

        static void Add(params int[]arr)
        {
            Console.WriteLine("params int[]arr");
        }
        static void Add(int x,int y)
        {
            Console.WriteLine("X&Y");
        }
    }
}
