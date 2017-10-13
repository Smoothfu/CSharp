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
            bool obj = false;
            Type type = obj.GetType();
            Console.WriteLine(type.Name);
            Console.ReadLine();
        }
    }
}
