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
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\txt.txt";

            using (StreamWriter streamWriter = File.CreateText(fileName))
            {
                streamWriter.WriteLine(fileName);
            }
                Console.ReadLine();
        }
    }
}
