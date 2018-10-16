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
          
            string fileName = @"myTxt.txt";
          
            File.Copy(fileName, "myTxtCopy.txt", true);
            Console.WriteLine(File.Exists(fileName));
            Console.WriteLine(File.Exists("myTxtCopy.txt"));
            Console.ReadLine();
        }
    }
}
