using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp277
{
    class Program
    {
        static void Main(string[] args)
        {
          string path=Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(path).Parent.Parent.Parent.Parent;
            FileInfo[] allFiles = dir.GetFiles("*",SearchOption.AllDirectories);
            if(allFiles!=null && allFiles.Any())
            {
                allFiles.ToList().ForEach(x =>
                {
                    Console.WriteLine(x.FullName);
                });

                Console.WriteLine("\n\n\nThere are totally {0} files in {1}", allFiles.Count(), dir.FullName);
            }

            Console.ReadLine();
        }
    }
}
