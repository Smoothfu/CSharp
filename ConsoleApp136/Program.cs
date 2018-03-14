using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp136
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\NewFile");
            if(dir.Exists==false)
            {
                dir.Create();
            }
            string destPath = string.Format(@"{0}", (Path.GetFullPath(dir.FullName)+"\\").ToString());
         
            string sourcePath = @"C:\Users\Fred\Pictures";
            string[] files = Directory.GetFiles(sourcePath);
            if(files!=null && files.Any())
            {
                foreach(var file in files)
                {
                    //Use static Path methods to extract only the file name from the path.
                    string fileName = Path.GetFileName(file);
                    string destPath2 = Path.Combine(destPath, fileName);
                    string[] desFiles = Directory.GetFiles(destPath);
                    if(!desFiles.Contains(destPath2))
                    {
                        File.Copy(file, destPath2, false);
                    }                   
                }
            }
            Console.WriteLine("*****Directory Info*****");
            Console.WriteLine("FullName: {0}\n", dir.FullName);
            Console.WriteLine("Name:{0}\n", dir.Name);
            Console.WriteLine("Parent:{0}", dir.Parent);
            Console.WriteLine("Creation:{0}\n", dir.CreationTime);
            Console.WriteLine("Attributes:{0}\n", dir.Attributes);
            Console.WriteLine("Root:{0}\n", dir.Root); 
            Console.WriteLine("***************************");
            Console.ReadLine();
        }
    }
}
