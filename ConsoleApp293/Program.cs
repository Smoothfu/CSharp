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
            //Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };


            //Define the query expression.
            IEnumerable<int> scoreQuery = from s in scores where s > 80 select s;

            //Execute the query.
            foreach(int i in scoreQuery)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }

        static void LINQWords()
        {
            string[] words = { "hello", "wonderful", "LINQ", "beautifulgril", "World" };

            ////get only short words
            //var shortWords = from word in words
            //                 where word.Length <= 5
            //                 select word;
            var shortWords = words.Where(x => x.Length <= 5);

            //print each word out.
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("The following are longer words:\n");
            var longWords = from w in words where w.Length >= 10 select w;
            foreach (var word in longWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
