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
            ModifyAppDirectory();

            Console.ReadLine();
        }

        static void DisplayImagesFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Fred\Pictures");

            //Get all files with a *.jpg extension.
            FileInfo[] imgFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            //How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imgFiles.Length);

            //Now print out info for each file.
            foreach(FileInfo fi in imgFiles)
            {
                Console.WriteLine("************************************************");
                Console.WriteLine("File name:{0}\n", fi.Name);
                Console.WriteLine("File size:{0}\n", fi.Length);
                Console.WriteLine("Creation:{0}\n", fi.CreationTime);
                Console.WriteLine("Attributes:{0}\n", fi.Attributes);
                Console.WriteLine("**************************************************\n");            }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            //Create \myFolder off application directory.
            dir.CreateSubdirectory("mySub");

            DirectoryInfo[] dirs = dir.GetDirectories("*", SearchOption.AllDirectories);
            if(dirs!=null && dirs.Any())
            {
                Console.WriteLine("There are {0} directories in the path\n\n\n", dirs.Length);
                dirs.All(x =>
                {
                    Console.WriteLine("{0},{1}",x.FullName,x.CreationTime); 
                    return true;
                });
            }
        }
    }
}
