using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp74
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);
            assembly.Modules.All(x => { Console.WriteLine(x.FullyQualifiedName);Console.WriteLine(x.GetType().Name);return true;});
            Console.ReadLine();
        }
    }
}
