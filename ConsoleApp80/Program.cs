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
            ListInterfaces(type);

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

        static void ListFields(Type type)
        {
            Console.WriteLine("*****Fields*****\n");
            var fieldNames = from f in type.GetFields() select f.Name;

            foreach(var name in fieldNames)
            {
                Console.WriteLine("Name: {0}\n", name);
            }

            Console.WriteLine("\n\n\n");
        }

        //Display property names of type.
        static void ListProperties(Type type)
        {
            Console.WriteLine("*****Properties*****\n\n");
            var propNames = from p in type.GetProperties() select p.Name;

            foreach(var name in propNames)
            {
                Console.WriteLine("Property :{0}\n", name);
            }
        }

        //Display implemented interfaces.
        static void ListInterfaces(Type type)
        {
            Console.WriteLine("*****Interfaces*****\n");
            var ifaces = from i in type.GetInterfaces() select i;
            foreach(Type i in ifaces)
            {
                Console.WriteLine("Name: {0}\n", i.Name);
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

        interface ICompute
        {
            void AddMethod(int x, int y);
            void SubractMethod(int x, int y);
        }

        interface ISum
        {
            void SumMethod(int x, int y);
            void SubtractMethod(int x, int y);
        }
    }
}
