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

            FileAttributes attributes = File.GetAttributes(fileName);
            Console.WriteLine(attributes);
            if((attributes&FileAttributes.ReadOnly)!=0)
            {
                Console.WriteLine("The {0} is ReadOnly!", fileName);
            }
           
            Console.ReadLine();
        }
    }
}
