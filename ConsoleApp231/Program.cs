using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp231
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(31, "Fred");
            ParameterizedThreadStart pts = new ParameterizedThreadStart(DescPerson);
            Thread thread = new Thread(pts);
            thread.Start(p);
            Console.ReadLine();            
        }

        public static void DescPerson(object obj)
        {
            var p = obj as Person;
            if(p!=null)
            {
                Console.WriteLine("Age:{0}\n", p.Age);
            }
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age)
        {
            Age = age;
        }
        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public static Person operator +(Person a,Person b)
        {
            return new Person(a.Age + b.Age);
        }
    }
}
