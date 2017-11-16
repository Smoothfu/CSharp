using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>();
            intList = Enumerable.Range(10, 100).ToList();
            //for(int i=0;i<10;i++)
            //{
            //    Random rnd = new Random();
            //    int value = rnd.Next(1, 10000);
            //    intList.Add(value);
            //}

            Console.WriteLine("Before:");
            intList.ForEach(x =>
            {
                Console.WriteLine(x);
            });


            Console.WriteLine("After: ");

            intList.ForEach(x =>
            {
                x = x * 10;
                Console.WriteLine(x);
            });

            Console.ReadLine();
        }
    }
}
