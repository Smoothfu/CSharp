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
            FileWriteAllTextReadAllText();
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

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Fred\Pictures");

            //Get all files with a *.jpg extension.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            //How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);

            //Now print out info for each file.

            foreach(FileInfo fi in imageFiles)
            {
                Console.WriteLine("*****************************\n");
                Console.WriteLine("File name:{0}\n", fi.Name);
                Console.WriteLine("File size:{0}\n", fi.Length);
                Console.WriteLine("Creation:{0}\n", fi.CreationTime);
                Console.WriteLine("Attributes:{0}\n", fi.Attributes);
                Console.WriteLine("******************************\n");
            }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\ABCD");

            //Create \ABCD off application directory.

            dir.CreateSubdirectory("MyFolder");

            //Create \ABCD\SubFoler off application directory.
            dir.CreateSubdirectory(@"MyFoler\ABCDE");

        }

        static void ModifyAppCreateDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            //Create \MyFolder off initial directory.
            dir.CreateSubdirectory("20180318");

            //Capture returned DirectoryInfo object.
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"20180318\data");

            //print path.FullName
            Console.WriteLine("New Folder is:{0}\n", myDataFolder.FullName);
        }

        static void FunWithDirectoryType()
        {
            //List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives: ");
            foreach(string str in drives)
            {
                Console.WriteLine("--> {0}\n", str);
            }

            //Delete what was created.
            Console.WriteLine("Press Enter to delete directories\n");
            Console.ReadLine();
            try
            {
                

                //The second parameter specifies whether you wish you destory any subdirectories.
                Directory.Delete(@"D:\C\ConsoleApp137\ConsoleApp137\bin\Debug\20180318", true);

            }

            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WorkWithDriveInfo()
        {
            Console.WriteLine("*****Fun with DriveInfo*****\n");

            //Get info regarding all drives.
            DriveInfo[] drives = DriveInfo.GetDrives();

            //Now print drive stats.
            foreach(DriveInfo di in drives)
            {
                Console.WriteLine("Name: {0}\n", di.Name);
                Console.WriteLine("Type: {0}\n", di.DriveType);

                //Check to see whether the drive is mounted.
                if(di.IsReady)
                {
                    Console.WriteLine("Free space:{0}\n", di.TotalFreeSpace);
                    Console.WriteLine("Format:{0}\n", di.DriveFormat);
                    Console.WriteLine("Label:{0}\n", di.VolumeLabel);
                }

                Console.WriteLine("\n\n\n");
            }
        }

        static void FileInfoCreateMethod()
        {
            //Make a new file on the c drive.
            FileInfo fi = new FileInfo(@".\test.txt");

            using (StreamWriter sw = fi.AppendText())
            {
                sw.WriteLine("The wonderful world,make every second count and make a difference");               
            }

            using (StreamReader sr = fi.OpenText())
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }

        }

        static void FIleInfoOpenTextMethod()
        {
            FileInfo fi = new FileInfo(@".\FileInfo.txt");

            //Check for existing file.
            //Create the file
            using (FileStream fs = fi.Create())
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This a wonderful and fair world,everything depend on myself,make every second count and make a difference!\n");

                //Add some information to the file.
                fs.Write(info, 0, info.Length);
                fs.Close();
            }

            //Open the stream and read it back.
            using (StreamReader sr = fi.OpenText())
            {
                string str = "";
                while((str=sr.ReadLine())!=null)
                {
                    Console.WriteLine(str);
                    System.Diagnostics.Debug.WriteLine(str);
                }
            }
        }

        static void FileAppenAllTextReadAllTExt()
        {
            FileInfo fi = new FileInfo(@".\FileInfoAppenAllText");
            string path = fi.FullName;

            //This text is added only once to the file.

            //Create a file to write to.
            string newText = "This is a wonderful and fair world,everything depend on myself,make every second count and make a difference!\n";
            File.AppendAllText(path, newText);


            //This text is always added,making the file longer over time
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }

        static void FileWriteAllTextReadAllText()
        {
            FileInfo fi = new FileInfo(@".\FileWriteAllText.txt");
            string path = fi.FullName;
            string writeText = "This is a wonderful and fair world. Cherish the current moment,make every second count and make a differnce!\n";
            File.AppendAllText(path, writeText);
            File.WriteAllText(path, writeText);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }
    }
}
