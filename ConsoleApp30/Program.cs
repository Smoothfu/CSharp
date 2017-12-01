using System;
using System.Collections.Generic;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach(var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            Console.ReadLine();
        }
    }
}
