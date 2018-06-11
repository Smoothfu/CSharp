using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ConsoleApp221
{
    class Program
    {
        static void Main(string[] args)
        {
            InitQueue();
            Console.ReadLine();
        }

        static void DisplayImagesFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Fred\Pictures");

            //Get all files with a *.jpg extension.
            FileInfo[] imgFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            //How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imgFiles.Length);

            //Now print out info for each file.
            foreach(FileInfo fi in imgFiles)
            {
                Console.WriteLine("************************************************");
                Console.WriteLine("File name:{0}\n", fi.Name);
                Console.WriteLine("File size:{0}\n", fi.Length);
                Console.WriteLine("Creation:{0}\n", fi.CreationTime);
                Console.WriteLine("Attributes:{0}\n", fi.Attributes);
                Console.WriteLine("**************************************************\n");            }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            //Create \myFolder off application directory.
            dir.CreateSubdirectory("mySub");

            DirectoryInfo[] dirs = dir.GetDirectories("*", SearchOption.AllDirectories);
            if(dirs!=null && dirs.Any())
            {
                Console.WriteLine("There are {0} directories in the path\n\n\n", dirs.Length);
                dirs.All(x =>
                {
                    Console.WriteLine("{0},{1}",x.FullName,x.CreationTime); 
                    return true;
                });
            }
        }

        static void FunWithDirectoryType()
        {
            //List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:\n");

            drives.All(x =>
                {
                    Console.WriteLine(x);
                    return true;
                });

            //Delete what was created.
            Console.WriteLine("Press Enter to delete directories\n");
            Console.ReadLine();
            try
            {
                

                //The second parameter specifies whether you wish to destory any subdirectories.
                Directory.Delete(@"D:\C\ConsoleApp221\ConsoleApp221\bin\Debug\sub", true);
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InitQueue()
        {
            //Creates and initializes a new queue.
            Queue mq = new Queue();
            mq.Enqueue("The world is fair");
            mq.Enqueue("Everything depend on myself");
            mq.Enqueue("Make every second count");

            //Displays the properties and values of the Queue.
            Console.WriteLine("mq:\n\n\n");
            Console.WriteLine("\tCount:{0}", mq.Count);
            Console.WriteLine("\tValues:");

            foreach(var m in mq)
            {
                Console.WriteLine(m);
            }

            Console.ReadLine();
        }
    }
}
