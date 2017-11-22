using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;


namespace ConsoleApp20
{
    class Program
    {
        static void DisplayTypesInAsm( )
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            var allFiles = Directory.GetFiles(filePath,"*.dll");
            foreach(var file in allFiles)
            {
                var asm = Assembly.LoadFrom(file);
                Type[] types = asm.GetTypes();
                foreach(var t in types)
                {
                    Console.WriteLine(t.FullName);
                }
            }
            
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            DisplayTypesInAsm();
            Console.ReadLine();            
        }
    }
}
