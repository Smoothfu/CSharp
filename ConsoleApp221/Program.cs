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
                    Console.WriteLine("Attributes:{0,-30}\t FullName:{1}",x.Attributes,x.FullName);                    
                    Console.WriteLine("");
                    return true;
                });
            }
            

            Console.ReadLine();
        }
    }
}
