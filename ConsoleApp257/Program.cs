using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp257
{
    interface IA
    {
        void AddMethod(int x, int y);
    }

    interface IB
    {
        void AddMethod(int x, int y);
    }

    class AddClass : IA, IB
    {
        void IA.AddMethod(int x, int y)
        {
            Console.WriteLine("In IA:{0}+{1}={2}\n", x, y, x + y);
        }

        void IB.AddMethod(int x, int y)
        {
            Console.WriteLine("In IB:{0}+{1}={2}\n", x, y, x + y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instane of Person and assign values to its fields.
            Person p1 = new Person();
            p1.Age = 31;
            p1.Name = "Fred";
            p1.IdInfo = new IdInfo(1000000);


            //Perform a shallow copy of p1 and assign it to p2.
            Person p2 = p1.ShallowCopy();

            //Display values of p1,p2
            Console.WriteLine("Original values of p1 and p2:\n");
            Console.WriteLine(" p1 instance values:\n");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values:\n");
            DisplayValues(p2);

            //Change the value of p1 properties and display the values of p1 and p2.
            p1.Age = 27;
            p1.Name = "LZY";
            p1.IdInfo.IdNumber = 787878787;
            Console.WriteLine("\nValues of p1 and p2 after changes to p1:\n");
            Console.WriteLine("p1 instance values:\n");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values:\n");
            DisplayValues(p2);
           
           
            Console.ReadLine();
        }

        static void DisplayValues(Person p)
        {
            Console.WriteLine("Name:{0:s},Age:{1:d}", p.Name, p.Age);
            Console.WriteLine("Value:{0:d}", p.IdInfo.IdNumber);
        }
    }

    public class IdInfo
    {
        public int IdNumber;
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    public class Person
    {
        public int Age;
        public string Name;
        public IdInfo IdInfo;


        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.IdInfo = new IdInfo(IdInfo.IdNumber);
            other.Name = string.Copy(Name);
            return other;
        }
    }
}
