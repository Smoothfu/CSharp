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
                FileInfo[] allFiles = parentDir.GetFiles("*", SearchOption.AllDirectories);
                if (allFiles != null && allFiles.Any())
                {
                    Console.WriteLine("There are totally {0} files in the {1}", allFiles.Count(), parentDir.FullName);
                    allFiles.All(x => {
                        Console.WriteLine(x.FullName);
                        return true;
                    });
                }
                Console.WriteLine("There are totally {0} files in the {1}", allFiles.Count(), parentDir.FullName);
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
