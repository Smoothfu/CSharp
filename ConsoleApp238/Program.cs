using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp238
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

        static void DescPerson(object obj)
        {
            var person = obj as Person;
            Console.WriteLine(person.ToString());

        }

    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("Name:{0},Age:{1}\n", Name, Age);
        }
    }
}
