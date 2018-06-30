using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp237
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(31, "Floomberg");
            ParameterizedThreadStart pts = new ParameterizedThreadStart(p.DescPerson);
            Thread thread = new Thread(pts);
            thread.Start(p);
            Console.ReadLine();
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

        public void DescPerson(object obj)
        {
            var personObj = obj as Person;
            if(personObj!=null)
            {
                Console.WriteLine(personObj.ToString());
            }
        }
        public override string ToString()
        {
            return string.Format("Name:{0},Age:{1}",Name,Age);
        }
    }
}
