using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp266
{ 
    class Program
    {
        static void Main(string[] args)
        {

            Person.UseGenericList();
            Console.ReadLine();
        }

        static void SimpleBoxUnboxOperation()
        {
            //Make a ValueType (int) variable.
            int myInt = 25;

            //Box the int into an object reference.
            object boxedInt = myInt;

            //Unbox in the wrong data type to trigger runtime exception.
            try
            {
                long unboxedINt = (long)boxedInt;
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ArrayListOfRandomObjects()
        {
            //The ArrayList can hold anything at all.
            ArrayList al = new ArrayList();
            al.Add(true);
            al.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            al.Add(66);
            al.Add(3.14);
        }
    } 

    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person()
        {

        }

        public Person(string firstName,string lastName,int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format("Name:{0}{1},Age:{2}\n", FirstName, LastName, Age);
        }

        public static void UseGenericList()
        {
            //Make a list of person objects,filled with collection/object init syntax.
            List<Person> personList = new List<Person>()
            {
                new Person { FirstName="Fred1",LastName="Fu1",Age=31},
                new Person { FirstName = "Fred2", LastName = "Fu2", Age = 32 },
                new Person { FirstName = "Fred3", LastName = "Fu3", Age = 33 },
                new Person { FirstName = "Fred5", LastName = "Fu5", Age = 35 },
                new Person { FirstName = "Fred6", LastName = "Fu6", Age = 36 },
                new Person { FirstName = "Fred7", LastName = "Fu7", Age = 37 },
                new Person { FirstName = "Fred8", LastName = "Fu8", Age = 38 }
            };

            //Print out # of items in list.
            Console.WriteLine("Items in list:{0}\n", personList.Count);

            //Enumerate over list.
            personList.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }
    }


    public class PersonCollection : IEnumerable
    {
        private ArrayList alPeople = new ArrayList();

        //Cast for caller.
        public Person GetPerson(int pos)
        {
            return (Person)alPeople[pos];
        }

        //Insert only person objects.
        public void AddPerson(Person p)
        {
            alPeople.Add(p);
        }

        public void ClearPeople()
        {
            alPeople.Clear();
        }

        public int Count
        {
            get
            {
                return alPeople.Count;
            }
        }
        
        public IEnumerator GetEnumerator()
        {
            return alPeople.GetEnumerator();
        }

       public static void InitPersonCollection()
        {
            List<Person> personList = new List<Person>();
            Console.WriteLine("*****Custom Person Collection*****");
            PersonCollection personCollection = new PersonCollection();
            personCollection.AddPerson(new Person("Fred1", "Fu1", 31));
            personCollection.AddPerson(new Person("Fred2", "Fu2", 32));
            personCollection.AddPerson(new Person("Fred3", "Fu3", 33));
            personCollection.AddPerson(new Person("Fred5", "Fu5", 35));
            personCollection.AddPerson(new Person("Fred6", "Fu6", 36));
            personCollection.AddPerson(new Person("Fred7", "Fu7", 37));
            personCollection.AddPerson(new Person("Fred8", "Fu8", 38));

            foreach(Person p in personCollection)
            {
                Console.WriteLine(p);
            }
        }
    }

    public class Car : IComparable,IComparable<Car>
    {
        //IComparable implementation.
        public int CompareTo(object obj)
        {
            Car tempCar = obj as Car;
            if (tempCar != null)
            {
                if (this.CarId > tempCar.CarId)
                {
                    return 1;
                }

                if (this.CarId < tempCar.CarId)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            else
            {
                throw new ArgumentException("Parameter is not a Car!");
            }
        }

        public int CompareTo(Car other)
        {
            if(this.CarId>other.CarId)
            {
                return 1;
            }

            if(this.CarId<other.CarId)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public int CarId { get; set; }
        
    }
}
