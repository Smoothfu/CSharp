using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ConsoleApp229
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The ManagedThreadId in Main method is {0}\n", Thread.CurrentThread.ManagedThreadId);
            DirectoryInfo dir = new DirectoryInfo(".");
            DirectoryInfo parentDir = dir.Parent.Parent.Parent.Parent;
            try
            {
                DirectoryInfo[] allDirss = parentDir.GetDirectories("*", SearchOption.AllDirectories);
                var allDirs = from d in allDirss
                              orderby d.CreationTime
                              select d;
                if(allDirs!=null && allDirs.Any())
                {
                    allDirs.All(x =>
                    {
                        Console.WriteLine(x.FullName);
                        return true;
                    });
                    Console.WriteLine("There are {0} directories in {1}", allDirs.Count(), parentDir.FullName);
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            

            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("The ManagerThreadId in Add method is {0}\n", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
