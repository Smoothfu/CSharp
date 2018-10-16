using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp278
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\C\ConsoleApp278\ConsoleApp278\bin\Debug\ConsoleApp278.exe";
            bool isExist = File.Exists(path);
            Console.WriteLine(isExist);
            Console.ReadLine();
        }
    }
}
