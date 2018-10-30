using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp278
{
    class Program
    {
        static void Main(string[] args)
        {
            Person floomberg = new Person();
            floomberg.Eat();
            Console.ReadLine();
        }
    }

    public abstract class Animal
    {
        public abstract void Eat();
    }

    public class Person:Animal
    {
        public override void Eat()
        {
            Console.WriteLine("The human being eat cooked food!");
        }
    }
}
