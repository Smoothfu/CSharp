using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp278
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\ConsoleApp278.exe";
            FileInfo fi = new FileInfo(fileName);
            Console.WriteLine(fi.CreationTime);
            Console.WriteLine(fi.Directory);
            Console.WriteLine(fi.Extension);
            Console.WriteLine(fi.FullName);
            Console.WriteLine(fi.IsReadOnly);
            Console.WriteLine(fi.Length);
            Console.ReadLine();
        }
    }
}
