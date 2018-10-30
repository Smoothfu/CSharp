using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp278
{
    public delegate void MathDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1235634, y = 65634576;
            Program obj = new Program();
            MathDel mathDel = new MathDel(obj.AddMethod);
            mathDel(x, y);

            Console.WriteLine("\n\n\n");
            mathDel = new MathDel(obj.SubMethod);
            mathDel(x, y);

            Console.WriteLine("\n\n\n");

            mathDel = new MathDel(obj.Multiply);
            mathDel(x, y);

            Console.WriteLine("\n\n\n");
            mathDel = new MathDel(obj.Divide);
            mathDel(x, y);
            
            Console.ReadLine();
        }

        public void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        public void SubMethod(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}\n", x, y, x - y);
        }

        public void Multiply(int x,int y)
        {
            Console.WriteLine("{0}*{1}={2}\n", x, y, x * y);
        }

        public void Divide(int x,int y)
        {
            Console.WriteLine("{0}/{1}={2}\n", x, y, x / y);
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
            Console.WriteLine("Floomberg should run 10000 m+ everyday!");
        }
    }

    
}
