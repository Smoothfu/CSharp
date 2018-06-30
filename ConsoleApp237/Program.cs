using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp237
{
    public delegate void AddHanler(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            AddHanler addDel = new AddHanler(AddMethod);
            addDel(13435, 442563454);
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
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
