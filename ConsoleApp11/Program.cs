using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Base
    {
        public override string ToString()
        {
            return "Base";
        }
    }

    class Derived : Base
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            Base b = d as Base;
            if(b!=null)
            {
                Console.WriteLine(b.ToString());
            }
            Console.ReadLine();
        }
    }
}
