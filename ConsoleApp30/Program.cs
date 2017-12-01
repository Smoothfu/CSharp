using System;
using System.Collections.Generic;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "<Fred>", "Ana", "Felipe" };
            foreach(var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            Console.WriteLine();
            names.Add("Maria");
            names.Add("nano");
            names.Add("nemo");

            foreach(var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine("\n");

            Console.WriteLine($"My name is {names[0]}");
            Console.WriteLine($"I've added {names[0]} and {names[3]} to the list");

            Console.WriteLine("\n\n");
            Console.WriteLine($"The list has {names.Count} people in it.");

            var index = names.IndexOf("Felipe");
            var secondIndex = index;
            if(index==-1)
            {
                Console.WriteLine($"When an item is not found,IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }

            index = names.IndexOf("Not Found");
            if(index==-1)
            {
                Console.WriteLine($"When an item is not found,IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }

            Console.WriteLine("\n\n");

            names.Sort();
            names.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            Console.ReadLine();
        }
    }
}
