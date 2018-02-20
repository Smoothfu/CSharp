using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp111
{
    class Program
    {
        static void Main(string[] args)
        {
            int val = 100;
            Add100(ref val);
            Console.WriteLine(val);
            Console.ReadLine();
        }

        static void Add100(ref int x)
        {
            x = x + 100;
        }
    }
}
