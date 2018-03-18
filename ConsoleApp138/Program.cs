using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp138
{
    class Program
    {
        static void Main(string[] args)
        {
            NewLogFile();
            Console.ReadLine();
        }

        static void NewLogFile()
        {            
            DirectoryInfo dir=new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            DirectoryInfo subDir = dir.CreateSubdirectory(@"Sub\Sub\Sub\SubFile\");

            var dt = DateTime.Now;
            var newDt = dt.AddMinutes(1);

            while ((DateTime.Now-newDt).Seconds<0)
            {
                string path = subDir + string.Format(DateTime.Now.ToString("yyyyMMddHHmmss")) + ".txt";

                string str = "This world is wonderful and fair,everything depend on myself,cherish the present moment,make every second count and make a difference!\n";

                File.AppendAllText(path, str);
            }

            string[] allFiles = Directory.GetFiles(subDir.FullName);

            Console.WriteLine("There are totally {0} files!\n\n\n", allFiles.Count());
            foreach (var file in allFiles)
            {
                string fileContent = File.ReadAllText(file);
                Console.WriteLine("Name: {0}\n", file);
                Console.WriteLine("Size:{0}\n", fileContent.Length);
            }
            Console.ReadLine();

        }
    }
}
