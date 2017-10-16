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
            MyClass obj = new MyClass("Fred");
            Type type = obj.GetType();
           

            MethodInfo[] mis = type.GetMethods();
            mis.All(x =>
            {
                Console.WriteLine(x.Module.FullyQualifiedName);
                Console.WriteLine(x.Name);
                Console.WriteLine(x.ReturnType);
                Console.WriteLine(x.MemberType);
                return true;
            });
            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public string _name;
        public MyClass(string name)
        {
            _name = name;
            Console.WriteLine("This is the constructor _name :{0}", _name);
        }

        public void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public int Subtract(int x,int y)
        {
            return x - y;
        }
    }
}
