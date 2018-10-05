using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ConsoleApp267
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun wih Generic Structures*****\n");

            //Point using ints.
            Point<int> intPoint = new Point<int>(10, 10);
            Console.WriteLine("intPoint.ToString()={0}\n", intPoint.ToString());
            intPoint.ResetPoint();
            Console.WriteLine("intPoint.ToString()={0}\n", intPoint.ToString());

            //Point using double.
            Point<double> doublePoint = new Point<double>(5.555555555555, 33333333333333.33);
            Console.WriteLine("doublePoint.ToString()={0}\n", doublePoint.ToString());
            doublePoint.ResetPoint();
            Console.WriteLine("doublePoint.ToString()={0}\n", doublePoint.ToString());

            Console.ReadLine();
        }

        private static void PersonCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //What was the action that caused the event?
            Console.WriteLine("Action for this event:{0}\n", e.Action);


            //They removed something.

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:\n");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p);
                }
            }

            //They added something
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //Now show the NEW items that were inserted.
                Console.WriteLine("Here are the NEW items:\n");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p);
                }
            }
        }

        static void GetAllFiles()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo rootDir = dir.Parent.Parent.Parent;
            FileInfo[] allFiles = rootDir.GetFiles("*.exe", SearchOption.AllDirectories);
            if (allFiles != null && allFiles.Any())
            {
                Console.WriteLine("There are totally {0} files in the {1}!\n\n\n\n\n", allFiles.Count(), rootDir.FullName);
                foreach (FileInfo file in allFiles)
                {
                    Console.WriteLine(file.FullName);
                }
            }
        }

        //Swap two integers
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        //Swap two person objects.
        static void Swap(ref Person a, ref Person b)
        {
            Person temp = a;
            a = b;
            b = temp;
        }         

        static void DisplayBaseClass<T>()
        {
            //BaseType is a method used in reflection,which will be examined in Chapter 15
            Console.WriteLine("Base class of {0} is {1}\n", typeof(T), typeof(T).BaseType);
        }

        //This method will swap any structure,but not classes.
        static void Swap<T>(ref T a,ref T b) where T:struct
        {

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
            foreach (Person p in setOfPersons)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            //Add a few new people,with various ages.
            setOfPersons.Add(new Person { FirstName = "Fred1", LastName = "Fu1", Age = 101 });
            setOfPersons.Add(new Person { FirstName = "Fred1", LastName = "Fu1", Age = 81 });

            //Still sorted by age!
            foreach (Person p in setOfPersons)
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

            foreach (string key in dic2.Keys)
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

    //A generic Point structure.
    public struct Point<T>
    {
        //Generic state date.
        private T xPos;
        private T yPos;

        //Generic constructor.
        public Point(T xVal, T yVal)
        {
            xPos = xVal;
            yPos = yVal;
        }

        //Generic properties.
        public T X
        {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
            }
        }

        public T Y
        {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", xPos, yPos);
        }

        //Reset fields to the default value of the type parameter.
        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
            
        }
    }


    //MyGenericClass derives from object,while contained items must be a class implementing IDrawable and must support a default ctor.
    public class MyGenericClass<T> where T:class,INotifyCollectionChanged,new()
    {

    }

    //<K> must extend ParentClass and have a default ctor, while <T> must be a struct and implement the generic IComparable interface.
    public class MyGenericClassKT<K,T> where K:ParentClass,new()
        where T:struct,IComparable<T>
    {

    }

    public class BasicMath<T> where T:operator +,operator -,operator *,operator /
    {
        public T Add(T arg1,T arg2)
        {
            return arg1 + arg2;
        }

        public T Subtract(T arg1,T arg2)
        {
            return arg1 - arg2;
        }

        public T Multiply(T arg1,T arg2)
        {
            return arg1 * arg2;
        }

        public T Divide(T arg1,T arg2)
        {
            return arg1 / arg2;
        }
    }
}
