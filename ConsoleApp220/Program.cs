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
            ShowWindowsDirectoryInfo(path); 
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
         
    }
}
