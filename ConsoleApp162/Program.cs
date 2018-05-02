using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp162
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filePath = path + "\\NewText.txt";

            //Defining a using scope for file I/O type is ideal.
            FileInfo fi = new FileInfo(filePath);

            using (FileStream fs = fi.Create())
            {
                //Use the FileStream object...
            }
        }
    }
}
