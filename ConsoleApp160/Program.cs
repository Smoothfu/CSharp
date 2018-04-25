using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp160
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            Console.WriteLine(dir.FullName);
            Console.WriteLine(dir.CreationTime);
            Console.WriteLine(dir.LastAccessTime);
            Console.WriteLine(dir.LastWriteTimeUtc);
            Console.WriteLine(dir.Name);
            Console.WriteLine(dir.Root);
            Console.WriteLine(dir.ToString());
            Console.ReadLine();
        }
    }
}
