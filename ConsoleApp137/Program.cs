using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp137
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriteAllTextReadAllText();
            Console.ReadLine();
        }

        static void FileWriteAllTextReadAllText()
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            DirectoryInfo subDir = dir.CreateSubdirectory(@"NewFile\\NEwFile\\NewFIle\");           

            var dt = DateTime.Now;
            var dtSpan = dt.AddMinutes(10);

            while(dt<dtSpan)
            {
                try
                {
                    string path = subDir.FullName + string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMddhhmm"));
                    FileInfo fi = new FileInfo(path);
                    string writeTxt = "This is a wonderful and fair world,everything depend on myself.Cherish the present moment,make every second count,make a difference " + DateTime.Now.ToString("yyyyMMdd:hhmmssfff") + "\n";
                    File.AppendAllText(path, writeTxt);                   
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                      
            Console.WriteLine();
        }
    }
}
