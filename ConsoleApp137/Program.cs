using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp137
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bind to the current working directory.
            DirectoryInfo dir = new DirectoryInfo(".");
            Console.WriteLine(dir.FullName);
            Console.ReadLine();
        }
    }
}
