using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;
using System.IO;

namespace ConsoleApp77
{
    class Program
    {
        static int fileCount = 0;
        static void Main(string[] args)
        {
            string path = @"D:\D";
            ListAllFileInfo(path);
            Console.WriteLine("There are {0} files\n", fileCount);
            Console.ReadLine();
        }

       static void ListAllFileInfo(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            FileSystemInfo[] fis = di.GetFileSystemInfos();

            foreach (FileSystemInfo fi in fis)
            {
                //Check whether it is Folder
                if(fi is DirectoryInfo)
                {
                    //iterate invoke.
                    ListAllFileInfo(fi.FullName);
                }

                else
                {
                    //output all the files path.
                    Console.WriteLine(fi.FullName);
                    fileCount++;
                }
            }
        }
    }
}
