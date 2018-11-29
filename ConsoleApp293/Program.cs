using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp293
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "hello", "wonderful", "LINQ", "beautiful", "World" };

            //get only short words
            var shortWords = from word in words
                             where word.Length <= 5
                             select word;

            //print each word out.
            foreach(var word in shortWords)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }
    }
}
