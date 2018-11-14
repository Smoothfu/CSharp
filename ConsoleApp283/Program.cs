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
            Person p1 = new Person(1, "Fred1");
            Person p2 = new Person(2, "Fred2");
            int result = p1.CompareTo(p2);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public class Person:IComparable,IEnumerable,IEquatable,IComparer
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
    }
}
