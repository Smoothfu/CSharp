using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp27
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic varType = "type";
            Console.WriteLine(varType.GetType());
            varType = new List<string>();
            Console.WriteLine(varType.GetType());
            Console.ReadLine();
        }
    }
}
