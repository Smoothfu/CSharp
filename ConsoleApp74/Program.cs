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
            MyClass obj = new MyClass();
            Type type = obj.GetType();
            object obj1 = Activator.CreateInstance(type);

            FieldInfo fi = type.GetField("_name");
            fi.SetValue(obj1, "Fred");


            PropertyInfo pi = type.GetProperty("_age");
            pi.SetValue(obj1, 30, null);

            MethodInfo mi = type.GetMethod("Add");
            mi.Invoke(obj1, null);
            Console.ReadLine();
            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string _name;
        public int _age;
        public MyClass(string name)
        {
            _name = name;
            Console.WriteLine("This is the constructor _name :{0}", _name);
        }

        public MyClass(int age)
        {
            _age = age;
            Console.WriteLine("This is the constructor _age: {0}", _age);
        }


        public MyClass(string name,int age)
        {
            _name = name;
            _age = age;
            Console.WriteLine("In the constructor the _name is {0},the _age is {1}", _name, _age);

        }
        public MyClass()
        {
            Console.WriteLine("This is the default constructor!");
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
