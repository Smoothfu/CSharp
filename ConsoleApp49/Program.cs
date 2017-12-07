using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MathClass);
            ListMethods(type);
            Console.ReadLine();
        }

        //Display method names of type.
        static void ListMethods(Type t)
        {
            Console.WriteLine("*****Methods*****");
            MethodInfo[] mis = t.GetMethods();

            foreach(MethodInfo mi in mis)
            {
                Console.WriteLine(mi.Name);
            }
        }
    }

    public class MathClass
    {
        public void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public void Subtract(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }

        public void Multiply(int x,int y)
        {
            Console.WriteLine("{0}*{1}={2}", x, y, x * y);
        }

        public void Divide(int x,int y)
        {
            Console.WriteLine("{0}/{1}={2}", x, y, x / y);
        }
    }
}
