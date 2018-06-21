using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp230
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(31, "Floomberg");
            ParameterizedThreadStart pts = new ParameterizedThreadStart(DescPerson);
            Thread thread = new Thread(pts);
            thread.Start(p);          

            Console.ReadLine();
        }

        static void DescPerson(object obj)
        {
            var p = obj as Person;
            if(p!=null)
            {
                Console.WriteLine(p.ToString());
            }
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
            return string.Format("Age:{0},Name:{1}\n", Age, Name);
        }
    }
}
