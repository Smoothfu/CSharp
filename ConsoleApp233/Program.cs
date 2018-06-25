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
            string[] allDrivess=Directory.GetLogicalDrives();
            if(allDrivess!=null && allDrivess.Any())
            {
                Console.WriteLine("There are {0} dirves in the {1}\n", allDrivess.Count(), Environment.MachineName);

                Parallel.ForEach(allDrivess, x =>
                {
                    Console.WriteLine(x);
                });
            } 
        }
    }
}
