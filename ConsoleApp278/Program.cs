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
          
            string fileName = @"myTxt3.txt";
          
            string destName = @"D:\C\ConsoleApp278\ConsoleApp278\myTxtmove3.txt";
            File.Move(fileName, destName);
            Console.WriteLine(File.Exists(destName));
            Console.ReadLine();
        }
    }
}
