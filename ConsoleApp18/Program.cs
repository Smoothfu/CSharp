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
            MathClass.ListProps(type);
            Console.ReadLine();
        }
    }

    public class MathClass 
    {

        public int num = 10000;
        public string thisString = "This string";
        public bool IsTrue = true;
        public char c = 'a';

        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }


        public int Z { get; set; }

        public string shortName { get; set; }
         
        public MathClass(int x,int y)
        {
            X = x;
            Y = y;
        }
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

        public static void ListFields(Type type)
        {
            Console.WriteLine("*****Fields*****");
            var fieldNames = from f in type.GetFields() select f.Name;

            foreach(var name in fieldNames)
            {
                Console.WriteLine("Field Name: " + name);
            }
        }

        //Display property names of type.
        public static void ListProps(Type type)
        {
            Console.WriteLine("****Properties****");
            var propNames = from p in type.GetProperties() select p.Name;

            foreach(var name in propNames)
            {
                Console.WriteLine("Name: " + name);
            }

        }
    }
}
