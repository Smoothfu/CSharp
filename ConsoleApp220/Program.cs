using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp220
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\C\ConsoleApp219";
            List<string> allFiles = GetAllFiles(path);

            if (allFiles != null && allFiles.Any())
            {
                Console.WriteLine("There are {0} files in the {1}\n\n\n", allFiles.Count(), path);
                allFiles.All(x =>
                {
                    Console.WriteLine(x);
                    return true;
                });
               
            }
            Console.ReadLine();
        }

        public static List<string> GetAllFiles(string dir)
        {
            return Directory.GetFiles(dir, "*", SearchOption.AllDirectories).ToList();
        }
         
    }
}
