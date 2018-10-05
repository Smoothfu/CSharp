using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp267
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.UseSortedSet();
            Console.ReadLine();
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("FirstName:{0},LastName:{1},Age:{2}\n", FirstName, LastName, Age);
        }

        public static void UseSortedSet()
        {
            //Make sure people with different ages.
            SortedSet<Person> setOfPersons = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person{FirstName="Fred1",LastName="Fu1",Age=91},
                new Person{FirstName="Fred1",LastName="Fu1",Age=1},
                new Person{FirstName="Fred1",LastName="Fu1",Age=31},
                new Person{FirstName="Fred1",LastName="Fu1",Age=31},
                new Person{FirstName="Fred1",LastName="Fu1",Age=11},
                new Person{FirstName="Fred1",LastName="Fu1",Age=21},
                new Person{FirstName="Fred1",LastName="Fu1",Age=41},
                new Person{FirstName="Fred1",LastName="Fu1",Age=71},
                new Person{FirstName="Fred1",LastName="Fu1",Age=51},
                new Person{FirstName="Fred1",LastName="Fu1",Age=31},
            };

            //Note the items are sorted by age!
            foreach(Person p in setOfPersons)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            //Add a few new people,with various ages.
            setOfPersons.Add(new Person { FirstName = "Fred1", LastName = "Fu1", Age = 101 });
            setOfPersons.Add(new Person { FirstName = "Fred1", LastName = "Fu1", Age = 81 });

            //Still sorted by age!
            foreach(Person p in setOfPersons)
            {
                Console.WriteLine(p);
            }
        }
    }

    public class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age > y.Age)
            {
                return 1;
            }

            if (x.Age < y.Age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
