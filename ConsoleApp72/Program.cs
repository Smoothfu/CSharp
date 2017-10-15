using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp72
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            Type type = obj.GetType();
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.Module.Assembly.FullName);
            Console.WriteLine(type.Module.FullyQualifiedName);
            Console.WriteLine(type.Module.MetadataToken);
            Console.WriteLine(type.Module.ModuleVersionId);
            Console.WriteLine(type.Assembly.FullName);
            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public void Subtract(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }
    }
}
