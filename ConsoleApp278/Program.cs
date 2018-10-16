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
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(currentPath);
            FileInfo[] files = dir.Parent.Parent.Parent.GetFiles("*", SearchOption.AllDirectories);
            if(files!=null && files.Any())
            {
                Console.WriteLine("There are {0} files in {1}.\n\n\n\n\n", files.Count(), dir.Parent.Parent.Parent.FullName);
                for (int i=0;i<files.Count();i++)
                {
                    Console.WriteLine(files[i].FullName);
                }

                
            }
            Console.ReadLine();
        }
    }
}
