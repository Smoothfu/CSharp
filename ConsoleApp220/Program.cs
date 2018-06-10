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
            ShowDriveInfo();
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

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            //Create myFolder off application directory.
            dir.CreateSubdirectory("myFolder");

            //Capture returned DirectoryInfo object.
            DirectoryInfo myDataFoler= dir.CreateSubdirectory(@"MyFolder2\Data");
            Console.WriteLine("New folder is :{0}\n", myDataFoler);
        }
         
        static void FunWithDirectoryInfo()
        {
            //List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:\n");

            foreach(string str in drives)
            {
                Console.WriteLine("-->{0}\n", str);
            }

            //Delete what was created.
            Console.WriteLine("Press Enter to delete directories!\n");
            Console.WriteLine();

            try
            {
                Directory.Delete(@"D:\C\ConsoleApp219\ConsoleApp219\obj\Debug",true);

                //The second parameter specifies whether you wish to destory any subdirectories.
                Directory.Delete(@"D:\C\ConsoleApp219\ConsoleApp219\bin", true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ShowDriveInfo()
        {
            Console.WriteLine("*****Fun with DriveInfo*****\n");

            //Get info regarding all drives.
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            //Now print drive stats.
            foreach(DriveInfo di in allDrives)
            {
                Console.WriteLine("Name:{0}\n", di.Name);
                Console.WriteLine("Type:{0}\n", di.DriveType);

                //Check to see whether the drive is mounted

            if(di.IsReady)
                {
                    Console.WriteLine("Free space:{0}\n", di.TotalFreeSpace);
                    Console.WriteLine("Format:{0}\n", di.DriveFormat);
                    Console.WriteLine("Label:{0}", di.VolumeLabel);
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
