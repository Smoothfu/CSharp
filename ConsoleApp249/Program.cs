using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ConsoleApp249
{
   //Multiple inheritance for interface types is a-okay
   interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();

        //--note possible name clash here!
        void Draw();
    }

    //Multiple interface inheritance ok.
    interface IShape:IDrawable,IPrintable
    {
        int GetNumbersOfSides();
    }

    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public int GetNumbersOfSides()
        {
            return 4;
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    class Square : IShape
    {
        void IDrawable.Draw()
        {
            Console.WriteLine("Draw to screen!");
        }

        void IPrintable.Draw()
        {
            Console.WriteLine("Draw to printer!");
        }

        int IShape.GetNumbersOfSides()
        {
            return 4;
        }

        void IPrintable.Print()
        {
            Console.WriteLine("IPrintable print.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with IEnumerable/IEnumerator*****\n");
            Population pops = new Population();
            
            //Hand over each person in the collection
            foreach(Person p in pops.famousPersons)
            {
                Console.WriteLine("Name:{0},Age:{1}\n", p.Name, p.Age);
            }
            Console.ReadLine();
        }
    }

    public class Population:IEnumerable
    {
        public Person[] famousPersons = new Person[5];

        //Fill with some Person objects upon startup.
        public Population()
        {
            famousPersons[0] = new Person("Bill Gates", 63);
            famousPersons[1] = new Person("Michael Blooberg", 76);
            famousPersons[2] = new Person("Jeff Bezos", 54);
            famousPersons[3] = new Person("Larry Ellison", 73);
            famousPersons[4] = new Person("Floomberg", 31);
        }

        public IEnumerator GetEnumerator()
        {
            //Return the array object's IEnumerator.
            return famousPersons.GetEnumerator();
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
}
