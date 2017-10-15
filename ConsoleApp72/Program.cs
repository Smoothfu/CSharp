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
            PropertyInfo[] listPropertyInfo = type.GetProperties();
            foreach(PropertyInfo pi in listPropertyInfo)
            {
                Console.WriteLine("Property name is :" + pi.Name);
            }


            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public int Num { get; set; }
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
