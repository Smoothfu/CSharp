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
            DisplayImageFiles();
            Console.ReadLine();
        }

        public static List<string> GetAllFiles(string dir)
        {
            return Directory.GetFiles(dir, "*", SearchOption.AllDirectories).ToList();
        }

        static void ShowWindowsDirectoryInfo(string path)
        {
            //Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(path);
            Console.WriteLine("*****Directory Info*****");
            Console.WriteLine("FullName:{0}\n", dir.FullName);
            Console.WriteLine("Name:{0}\n", dir.Name);
            Console.WriteLine("Parent:{0}\n", dir.Parent);
            Console.WriteLine("Creation:{0}\n", dir.CreationTime);
            Console.WriteLine("Attributes:{0}", dir.Attributes);
            Console.WriteLine("Root:{0}\n", dir.Root);
            Console.WriteLine("************************************************************");
        }

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Fred\Pictures");

            //Get all files with *.jpg extension
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            if(imageFiles==null || !imageFiles.Any())
            {
                return;
            }

            Console.WriteLine("There are totally {0} *.jpg files\n", imageFiles.Length);

            //Now print out info for each file.
            foreach(FileInfo fi in imageFiles)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("File name:{0}\n", fi.Name);
                Console.WriteLine("File Size:{0}\n", fi.Length);
                Console.WriteLine("Creation:{0}\n", fi.CreationTime);
                Console.WriteLine("Attributes:{0}\n", fi.Attributes);
                Console.WriteLine("******************************");

            }
        }
         
    }
}
