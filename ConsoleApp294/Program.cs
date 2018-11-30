﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp294
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet barley = new Pet { Name = "Barley", Age = 4 };
            Pet boots = new Pet() { Name = "Boots", Age = 1 };
            Pet whiskers = new Pet() { Name = "Whiskers", Age = 6 };

            List<Pet> pets1 = new List<Pet>() { barley, boots };
            List<Pet> pets2 = new List<Pet> { barley, boots };
            List<Pet> pets3 = new List<Pet> { barley, boots, whiskers };

            bool equal = pets1.SequenceEqual(pets2);
            bool equal2 = pets1.SequenceEqual(pets3);

            Console.WriteLine("The lists pets1 and pets2 {0} equal.", equal ? "are" : "are not");
            Console.WriteLine("The lists pets1 and pets3 {0} equal.", equal2 ? "are" : "are not");
            Console.ReadLine();
        }

        static void LINQExcept()
        {
            double[] numbers1 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };
            IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);
            foreach (double number in onlyInFirstSet)
            {
                Console.WriteLine(number);
            }

        }

        static void LINQEnumerableRepeat()
        {
            IEnumerable<string> strings = Enumerable.Repeat("I like programming.", 30);

            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
        }

        static void LINQEnumerangeRange()
        {
            //Generate a sequence of integers from 1 to 5
            //and select their squares.
            IEnumerable<int> cubes = Enumerable.Range(1, 50).Select(x => x * x * x);
            foreach (int i in cubes)
            {
                Console.WriteLine(i);
            }
        }
        static void  LINQDefaultIfEmpty()
        {

            Pet barley = new Pet() { Name = "Barley", Age = 4 };
            Pet boots = new Pet() { Name = "Boots", Age = 1 };
            Pet whiskers = new Pet() { Name = "Whiskers", Age = 6 };
            Pet bluemoon = new Pet() { Name = "Blue Moon", Age = 9 };
            Pet daisy = new Pet() { Name = "Daisy", Age = 3 };

            List<Pet> pets = new List<Pet>() { barley, boots, whiskers, bluemoon, daisy };

            foreach (var pet in pets.DefaultIfEmpty())
            {
                Console.WriteLine("Name={0}\n", pet.Name);
            }
        }
        static void PartitionOperators()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> lessThan5 = arr.OrderByDescending(x=>x).TakeWhile(x => x >= 5);
            foreach(int i in lessThan5)
            {
                Console.WriteLine(i);
            }

        }

        static void LINQQuantifierOperator()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool AllBiggerThan5 = arr.All(x => x > 5);
            Console.WriteLine("AllBiggerthan5={0}\n", AllBiggerThan5);
            bool AnyBiggerThan5 = arr.Any(x => x > 5);
            Console.WriteLine("AnyBiggerThan5={0}\n", AnyBiggerThan5);
            bool Contain10 = arr.Contains(10);
            Console.WriteLine("Contain10={0}\n", Contain10);
        }
        static void LINQSum()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sum = arr.Sum(x => x);
            Console.WriteLine("Sum={0}\n", sum);
            int max = arr.Max();
            Console.WriteLine("Max={0}\n", max);
            int min = arr.Min();
            Console.WriteLine("Min={0}\n",min);
            double avg = arr.Average();
            Console.WriteLine("Avg={0}\n",avg);
        }
    }

    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
