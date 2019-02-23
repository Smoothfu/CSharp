using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ConsoleApp326
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedDerivedClass obj = new DerivedDerivedClass();
            var attrs = Attribute.GetCustomAttributes(typeof(DerivedDerivedClass), true);
            if(attrs!=null && attrs.Any())
            {
                foreach(var att in attrs)
                {
                    var custAtt = att as CustomAttribute;
                    if (custAtt != null)
                    {
                        Console.WriteLine($"Id:{custAtt.Id},Name:{custAtt.Name}");
                    }
                }
            }
            Console.ReadLine();
        }

    }
    [System.AttributeUsage(AttributeTargets.All,AllowMultiple =true)]
    public class CustomAttribute:Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomAttribute(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }

    [CustomAttribute(1,"Fred1")]
    public class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine($"This is {typeof(BaseClass).Name}");
        }
    }

    [CustomAttribute(2,"Fred2")]
    public class DeriveClass:BaseClass
    {
        public DeriveClass()
        {
            Console.WriteLine($"This is {typeof(DeriveClass).Name}");
        }
    }

    [CustomAttribute(3, "Fred3")]
    public class DerivedDerivedClass : DeriveClass
    {
        public DerivedDerivedClass()
        {
            Console.WriteLine($"This is {typeof(DerivedDerivedClass).Name}");
        }
    }
}
