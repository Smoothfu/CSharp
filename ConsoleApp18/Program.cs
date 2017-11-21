using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MathClass);
            MathClass.GetMethodOfType(type);
            Console.ReadLine();

        }
    }

    public class MathClass
    {
        public void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public void SubtractMethod(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }

        public void MultiplyMethod(int x,int y)
        {
            Console.WriteLine("{0}*{1}={2}", x, y, x * y);
        }

        public static void GetMethodOfType(Type type)
        {
            Console.WriteLine("****Methods*****");
            var methodNames = from name in type.GetMethods() select name.Name;
            foreach(var name in methodNames)
            {
                Console.WriteLine("Name: " + name);
            }
        }
    }
}
