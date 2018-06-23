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
            Thread thread = new Thread(() =>
              {
                  AddMethod(10, 20);
              });

            thread.Start();
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
