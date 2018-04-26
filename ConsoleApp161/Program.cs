using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp161
{
    class Program
    {
        static List<string> allFilesList = new List<string>();
        static List<string> allDirsList = new List<string>();
        static void Main(string[] args)
        {
            string fullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] allPathes = fullPath.Split(new string[] { "\\" }, StringSplitOptions.None);
            string parentPath = allPathes[0] + "\\" + allPathes[1] + "\\" + allPathes[2];
            DirectoryInfo dir = new DirectoryInfo(parentPath);
            ProcessDir(dir);
            Console.WriteLine("There are totally {0} files in the {1} directory!\n", allFilesList.Count, dir.FullName);
            allFilesList.ForEach(x =>
            {
                Console.WriteLine(x);
            });

            Console.WriteLine("\n\n\n\nThere are totally {0} directories in the {1} directory!\n",allDirsList.Count, dir.FullName);
            allDirsList.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            Console.ReadLine();
        }

        static void ProcessFile(DirectoryInfo dir)
        {
            string[] allFiles = Directory.GetFiles(dir.FullName);
            foreach(var file in allFiles)
            {
                allFilesList.Add(file);
            }
        }

        static void ProcessDir(DirectoryInfo directoryInfo)
        {
            DirectoryInfo[] allDirs = directoryInfo.GetDirectories();             
            allDirs.AsEnumerable<DirectoryInfo>().ToList().ForEach(x =>
            {                 
                ProcessDir(x);
                allDirsList.Add(x.FullName);
            }); 

            foreach(var ad in allDirs)
            {
                ProcessFile(ad);                
            }
        }
    }
}
