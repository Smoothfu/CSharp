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
            //Make an array of string data.
            string[] stringArray = { "First", "Second", "Third" };

            //Show number if items in array using length property.
            Console.WriteLine("This array has {0} items.\n", stringArray.Length);
            Console.WriteLine();

            

            //Display contents using enumerator.
            foreach(string str in stringArray)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            //Reverse the array and print again.
            Array.Reverse(stringArray);
            foreach(string str in stringArray)
            {
                Console.WriteLine("Array Entry:{0}\n", str);
            }

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
    }
}
