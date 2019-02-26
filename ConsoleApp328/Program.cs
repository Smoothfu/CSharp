using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp328
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomizeAttributes();
            Console.ReadLine();
        }

        static void CustomizeAttributes()
        {
            var attrs = Attribute.GetCustomAttributes(typeof(DerivedDerivedClass), true);
            if(attrs!=null && attrs.Any())
            {
                foreach(var att in attrs)
                {
                    var animal = att as AnimalAttribute;
                    Console.WriteLine($"Id {animal.Id},Name {animal.Name}");
                }
            }
        }
    }

    [System.AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    public class AnimalAttribute:Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Animal(Id =1,Name ="Fred1")]
    public class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine($"This is {typeof(BaseClass).Name}");
        }
    }

    [Animal(Id =2,Name ="Fred2")]
    public class DerivedClass:BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine($"This is {typeof(DerivedClass).Name}");
        }
    }

    [Animal(Id=3,Name ="Fred3")]
    [Animal(Id =4,Name ="Fred4")]
    [Animal(Id =5,Name ="Fred5")]
    public class DerivedDerivedClass:DerivedClass
    {
        public DerivedDerivedClass()
        {
            Console.WriteLine($"This is {typeof(DerivedDerivedClass).Name}");
        }
    }
}
