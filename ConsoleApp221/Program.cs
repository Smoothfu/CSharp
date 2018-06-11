using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp221
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\C\ConsoleApp220");
            DirectoryInfo [] allDirs= dir.GetDirectories("*",SearchOption.AllDirectories);

            if(allDirs!=null && allDirs.Any())
            {
                Console.WriteLine("There are {0} totally directories\n\n\n", allDirs.Count());
                allDirs.All(x =>
                {
                    Console.WriteLine(x.FullName);
                    return true;
                });
            }

            Console.ReadLine();
        }
    }
}
