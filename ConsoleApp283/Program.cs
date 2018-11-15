using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp283
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random rnd = new Random();
            for(int i=0;i<100;i++)
            {
                arr[i] = rnd.Next(1, 1111);
            }

            Parallel.ForEach(arr, x =>
            {
                Console.WriteLine(x);
                Console.WriteLine("This is {0}\n", x);
                Console.ReadLine();
            });
            Console.ReadLine();
        }
    }

    public class Person:IComparable,IEnumerable,IEquatable,IComparer,IComparer<Person>,IComparable<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(object obj)
        {
            if(obj==null)
            {
                return 1;
            }
            var person = obj as Person;
            if(person!=null)
            {
                return this.Id.CompareTo(person.Id);
            }

            else
            {
                throw new ArgumentException("Object is not a person");
            }
            
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Compare(object x, object y)
        {
            var personX = x as Person;
            var personY = y as Person;

            if(personX!=null && personY!=null)
            {
                if(personX.Id==personY.Id && personX.Name==personY.Name)
                {
                    return 0;
                }

                if(personX.Id>personY.Id)
                {
                    return 1;
                }

                if(personX.Id<personY.Id)
                {
                    return -1;
                }
            }

            return -1;
        }

        public int Compare(Person x, Person y)
        {
            return x.Id.CompareTo(y.Id);
        }

        public int CompareTo(Person other)
        {
            if(this.Id>other.Id)
            {
                return 1;
            }
            else if(this.Id<other.Id)
            {
                return -1;
            }
            return 0;
        }
    }
}
