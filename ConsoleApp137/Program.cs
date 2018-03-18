using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp137
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowWindowsDirectoryInfo();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            //Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("*****Directory Info*****\n");
            Console.WriteLine("FullName:{0}\n", dir.FullName);
            Console.WriteLine("Name:{0}\n", dir.Name);
            Console.WriteLine("Parent:{0}\n", dir.Parent);
            Console.WriteLine("Creation:{0}\n", dir.CreationTime);
            Console.WriteLine("Root:{0}\n", dir.Root);
            Console.WriteLine("******************************\n");
        }
    }
}
