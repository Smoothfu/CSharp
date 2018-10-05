using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ConsoleApp267
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo rootDir = dir.Parent.Parent.Parent;
            FileInfo[] allFiles= rootDir.GetFiles("*.exe", SearchOption.AllDirectories);
            if (allFiles != null && allFiles.Any())
            {
                Console.WriteLine("There are totally {0} files in the {1}!\n\n\n\n\n", allFiles.Count(), rootDir.FullName);
               foreach(FileInfo file in allFiles)
                {
                    Console.WriteLine(file.FullName);
                }
            }
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

        public static void UseDictionary()
        {
            //Populate using Add() method.
            Dictionary<string, Person> personDic = new Dictionary<string, Person>();
            personDic.Add("Fred1", new Person { FirstName = "Fred1", LastName = "Fu1", Age = 31 });
            personDic.Add("Fred2", new Person { FirstName = "Fred2", LastName = "Fu2", Age = 32 });
            personDic.Add("Fred3", new Person { FirstName = "Fred3", LastName = "Fu3", Age = 33 });
            personDic.Add("Fred5", new Person { FirstName = "Fred4", LastName = "Fu5", Age = 35 });
            personDic.Add("Fred6", new Person { FirstName = "Fred6", LastName = "Fu6", Age = 36 });

            foreach (var p in personDic)
            {
                Console.WriteLine(p.Value);
            }

            Console.WriteLine("\n\n\n\n\n");

            //Get Fred1
            Person p2 = personDic["Fred1"];
            Console.WriteLine(p2);

            Dictionary<string, Person> dic2 = new Dictionary<string, Person>()
            {
                ["Fred1"] = new Person { FirstName = "Fred1", LastName = "Fu1", Age = 31 },
                ["Fred2"] = new Person { FirstName = "Fred2", LastName = "Fu2", Age = 32 },
                ["Fred3"] = new Person { FirstName = "Fred3", LastName = "Fu2", Age = 33 }
            };

            Console.WriteLine("\n\n\nThis is the new dictionary!");

            foreach(string key in dic2.Keys)
            {
                Console.WriteLine(key);
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
