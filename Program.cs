using System;

namespace ConsoleApp307
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "This is a string which consist of any character that is part of the Unicode character set";
            string[] arr = str.Split(" ", StringSplitOptions.None);
            if(arr!=null && arr.Length>0)
            {
                foreach(string a in arr)
                {
                    Console.WriteLine(a);
                }
            }
            Console.ReadLine();
        }
    }
}
