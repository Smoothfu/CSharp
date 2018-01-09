using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;
using System.Configuration;
using System.Reflection;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("ConsoleApp80.MathClass");
            ListMethods(type);

            Console.ReadLine();
        }

        //Display method names of type.
        static void ListMethods(Type type)
        {
            Console.WriteLine("*****Methods information*****\n");
            MethodInfo[] mis = type.GetMethods();
            foreach(MethodInfo mi in mis)
            {
                Console.WriteLine("Name: {0}\n", mi.Name);
                Console.WriteLine("Module: {0}\n", mi.Module);
                Console.WriteLine("MemberType: {0}\n", mi.MemberType);
                Console.WriteLine("\n\n");
            }
        }
    }

    public class MathClass
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Sum = 0;

        public MathClass()
        {

        }

        public MathClass(int x,int y)
        {
            X = x;
            Y = y;
        }

        public void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        public void Subtract(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}\n", x, y, x - y);
        }

        public int Multiply(int x,int y)
        {
            return x * y;
        }

        public int Divide(int x,int y)
        {
            if(y==0)
            {
                throw new DivideByZeroException();
            }
            return x / y;
        }

        public virtual void RemainMethod(int x,int y)
        {
            if(y==0)
            {
                throw new DivideByZeroException();
            }

            Console.WriteLine("{0}%{1}={2}\n", x, y, x % y);
        }

        public delegate void MathDel(int x, int y);
        public event MathDel MathEvent;
    }
}
