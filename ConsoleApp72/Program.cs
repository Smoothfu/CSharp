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
            Type type = typeof(MyClass);
            MethodInfo[] mis = type.GetMethods();
            foreach(MethodInfo mi in mis)
            {
                Console.WriteLine(mi.Module.Assembly.FullName);
                Console.WriteLine(mi.Name);
                Console.WriteLine(mi.ReturnType);
                Console.WriteLine(mi.ReturnParameter);
            }

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

        public int Multiply(int x,int y)
        {
            return x * y;
        }
    }
}
