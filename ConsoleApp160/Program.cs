using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp160
{
    class Program
    {
        static List<string> fileList = new List<string>();
        static List<string> allFileDirectories = new List<string>();
        static void Main(string[] args)
        {
            string path = @"D:\C\ConsoleApp160";
            ProcessDir(path);

            Console.WriteLine("\n\n\n\n\n");
            
            if(fileList!=null && fileList.Any())
            {
                Console.WriteLine("There are totally {0} files in the diretory!\n\n\n", fileList.Count);
                fileList.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }

            if(allFileDirectories!=null && allFileDirectories.Any())
            {
                Console.WriteLine("\n\n\n There are totally {0} directories in the directory!\n\n\n\n", allFileDirectories.Count);
                allFileDirectories.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }
            Console.ReadLine();
        }

        static void ProcessDir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            FileInfo[] allFiles = dir.GetFiles();
            {
                if(allFiles!=null && allFiles.Any())
                {
                    foreach(var file in allFiles)
                    {
                        ProcessFile(file);
                    }
                }
            }

            DirectoryInfo[] allDirectoryInfo = dir.GetDirectories();

            if(allDirectoryInfo!=null && allDirectoryInfo.Any())
            {
                allDirectoryInfo.All(x =>
                {
                    allFileDirectories.Add(x.FullName);
                    ProcessDir(x.FullName);
                    return true;
                });
            }
        }


        static void ProcessFile(FileInfo fi)
        {
            Console.WriteLine(fi.CreationTimeUtc);
            Console.WriteLine(fi.Directory);
            Console.WriteLine(fi.FullName);
            Console.WriteLine(fi.GetHashCode());
            Console.WriteLine(fi.GetType().Name);
            Console.WriteLine(fi.ToString());
            fileList.Add(fi.FullName);
            Console.WriteLine("\n\n");
        }
    }
}
