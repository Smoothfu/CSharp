using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Program);
            Console.WriteLine(type.AssemblyQualifiedName);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.Name);
            Console.ReadLine();
        }
    }
}
