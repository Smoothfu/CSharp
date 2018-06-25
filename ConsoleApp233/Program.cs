using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp233
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryGetLogicalDrives();
            Console.ReadLine();
        }

        static void DirectoryGetLogicalDrives()
        {
            //Get info regarding all drives.
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            object lockObj = new object();


            //Now print drive stats.
            if (allDrives != null && allDrives.Any())
            {
                Console.WriteLine("There are {0} drives in {1}\n", allDrives.Count(), Environment.MachineName);

                Parallel.ForEach(allDrives, x =>
                {
                     
                        Console.WriteLine("Name:{0}\n", x.Name);
                        Console.WriteLine("Type:{0}\n", x.DriveType);

                            //check to see whether the drive is mounted.
                        if (x.IsReady)
                        {
                            Console.WriteLine("Free space:{0}\n", x.TotalFreeSpace);
                            Console.WriteLine("Format:{0}\n", x.DriveFormat);
                            Console.WriteLine("Label:{0}\n", x.VolumeLabel);
                        }
                        Console.WriteLine("\n");
                     
                });
            }

        }
    }
}
