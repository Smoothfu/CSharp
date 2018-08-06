using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp251
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with IEnumerable/IEnumerator*****\n");

            Population pop = new Population();
            
            foreach(var p in pop)
            {
                var per = p as Person;
                if(per!=null)
                {
                    Console.WriteLine("Name:{0},Age:{1}\n", per.Name, per.Age);
                }
            }
            
            Console.ReadLine();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Population:IEnumerable
    {
        Person[] personArray = new Person[5];

        //Fill with some persons upon startup.
        public Population()
        {
            personArray[0] = new Person("Fred", 31);
            personArray[1] = new Person("LJ", 30);
            personArray[2] = new Person("ZFF", 31);
            personArray[3] = new Person("MN", 23);
            personArray[4] = new Person("ML", 23);
        }

        public IEnumerator GetEnumerator()
        {
            return personArray.GetEnumerator();
        }
    }
}
