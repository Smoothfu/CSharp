using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp337
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteClass cc = new ConcreteClass();
            cc.VirtualMethod();
            Console.ReadLine();
        }

        static void TestOverload()
        {
            Add(0);
            Add(1, 2);
            Add(1, 2, 3);
        }
        static void Add(params int[]arr)
        {
            Console.WriteLine("params int[]arr");
        }
        static void Add(int x,int y)
        {
            Console.WriteLine("X&Y");
        }
    }

    public abstract class AbstractClass
    {
        public virtual void VirtualMethod()
        {
            Console.WriteLine("Virtual method in abstract class");
        }
    }

    public class ConcreteClass:AbstractClass
    {

    }
}
