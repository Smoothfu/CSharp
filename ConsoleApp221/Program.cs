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
          string[] allFiles=Directory.GetFiles(@"D:\C\ConsoleApp220","*",SearchOption.AllDirectories);
          if(allFiles!=null && allFiles.Any())
            {
                Console.WriteLine("There are {0} totally files in the path\n\n\n", allFiles.Count());
                allFiles.All(x =>
                {
                    Console.WriteLine(x);
                    return true;
                });
            }
            Console.ReadLine();
        }
    }
}
