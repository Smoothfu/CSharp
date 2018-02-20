using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp112
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1000000000;
            Add10000000(ref i);
            Console.WriteLine(i);
            Console.ReadLine();
        }

        static void Add10000000(ref int i)
        {
            i = i + 10000000;
        }
    }
}
