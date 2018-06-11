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
            FileInfo [] fis=dir.GetFiles("*", SearchOption.AllDirectories);

            if(fis!=null && fis.Any())
            {
                Console.WriteLine("There are totally {0} files in the specified path!\n\n\n",fis.Count());
                fis.All(x =>
                {
                    Console.WriteLine(x.Attributes);
                    Console.WriteLine(x.CreationTime);
                    Console.WriteLine(x.Directory);
                    Console.WriteLine(x.DirectoryName);
                    Console.WriteLine(x.FullName);
                    Console.WriteLine(x.LastAccessTime);
                    Console.WriteLine(x.LastWriteTime);
                    Console.WriteLine(x.Length);
                    Console.WriteLine(x.Name);
                    Console.WriteLine(x.ToString());
                    Console.WriteLine("\n\n\n");
                    return true;
                });
            }
            

            Console.ReadLine();
        }
    }
}
