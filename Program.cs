using System;

namespace ConsoleApp307
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello, world!";
            int len = str.Length;
            int pos = str.IndexOf(" ");
            string firstWord, secondWord;
            firstWord = str.Substring(0, pos);
            secondWord = str.Substring(pos + 1, (len - 1) - (pos + 1));
            Console.WriteLine("First word: " + firstWord);
            Console.WriteLine("Second Word: " + secondWord);
            Console.ReadLine();
        }
    }
}
