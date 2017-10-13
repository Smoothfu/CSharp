using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp69
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("System.String");
            Console.WriteLine(type.Name);
            Console.ReadLine();
        }
    }
}
