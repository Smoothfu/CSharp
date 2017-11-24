using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ConsoleApp23
{
    class Program
    {
        private static void DisplayInfo(Assembly asm)
        {
            Console.WriteLine("*****Info about Assembly*****");
            Console.WriteLine("Loaded from GAC?{0}", asm.GlobalAssemblyCache);
            Console.WriteLine("Asm Name:{0}", asm.GetName().Version);
            Console.WriteLine("Asm Culture:{0}", asm.GetName().CultureInfo.DisplayName);
            Console.WriteLine("\nHere are the public enums: ");


            //Use a LINQ query to find the public enums
            Type[] types = asm.GetTypes();
            var publicEnums = from pe in types where pe.IsEnum && pe.IsPublic select pe;

            foreach(var pe in publicEnums)
            {
                Console.WriteLine(pe);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*****The Shared Asm Reflector App*****\n");

            //Load System.Windows.Forms.dll from GAC
            string displayName = null;
            displayName = "System.Windows.Forms," +
                "Version=4.0.0.0," +
                "PublicKeyToken=b77a5c561934e089," +
                @"Culture=""";
            Assembly asm = Assembly.Load(displayName);
            DisplayInfo(asm);
            Console.ReadLine();
        }
    }
}
