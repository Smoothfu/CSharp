using System;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("UTC time: \t {0}", dt.ToFileTimeUtc());
            Console.WriteLine("Local time: \t {0}", dt.ToLocalTime());
            Console.WriteLine("Long Date: \t {0}", dt.ToLongDateString());
            Console.WriteLine("Long Time: \t {0}", dt.ToLongTimeString());
            Console.WriteLine("OA Date: \t {0}", dt.ToOADate());
            Console.WriteLine("Short Date:  \t {0}", dt.ToShortDateString());
            Console.WriteLine("Short Time:  \t {0}", dt.ToShortTimeString());
            Console.WriteLine("ToString():  \t {0}", dt.ToString());
            Console.WriteLine("UniversalTime:   \t {0}", dt.ToUniversalTime());
            Console.ReadLine();
        }
    }
}
