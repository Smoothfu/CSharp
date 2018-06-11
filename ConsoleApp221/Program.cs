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
            DirectoryInfo dir = new DirectoryInfo(".");
            DirectoryInfo subDir = dir.CreateSubdirectory(@"sub\sub\subFile");
            Console.WriteLine(subDir.FullName);
            Console.WriteLine(subDir.CreationTime);
            Console.WriteLine(subDir.Name);
            Console.WriteLine(subDir.LastAccessTime);
            Console.WriteLine(subDir.LastWriteTime);

            Console.ReadLine();
        }
    }
}
