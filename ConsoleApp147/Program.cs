using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp147
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******The Amazing File Watcher App******\n");

            //Establish the path to the directory to watch.
            FileSystemWatcher watcher = new FileSystemWatcher();

            try
            {
                watcher.Path = @"C:\Users\Fred\Downloads\金庸作品集世纪新修版【TXT】";
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return; 
            }

            //Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            //Only watch text files

            watcher.Filter = "*.txt";

            //Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);


            //Begin watching the directory.
            watcher.EnableRaisingEvents = true;

            //Wait for the user to quit the program.
            Console.WriteLine(@"Press 'q' to quit app.\n");
            while(Console.Read()!='q')
            {
                ;
            }
            Console.ReadLine();
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            //Specify what is done when a file is renamed.
            Console.WriteLine("File:{0} renamed to {1}\n", e.OldFullPath, e.FullPath);
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            //Specify what is done when a file is changed,created,or deleted.
            Console.WriteLine("File:{0} {1}!", e.FullPath, e.ChangeType);
        }
    }
}
