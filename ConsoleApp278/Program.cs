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
            floomberg.Run();
            Console.ReadLine();
        }
    }

    public abstract class Animal
    {
        public abstract void Eat();
        public virtual void Run()
        {
            Console.WriteLine("The live animal can run!");
        }
    }

    public class Person:Animal
    {
        public override void Eat()
        {
            Console.WriteLine("The human being eat cooked food!");
        }

        public override void Run()
        {
            Console.WriteLine("Floomberg should run 10000 m everyday!");
        }
    }
}
