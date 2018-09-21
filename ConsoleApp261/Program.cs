using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp261
{

    public abstract class BaseClass
    {
        public virtual void Subtract(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}\n", x, y, x - y);
        }
        public void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }

    public class DeriveA : BaseClass
    {
        public override void Subtract(int x, int y)
        {
            Console.WriteLine("In DeriveA,{0}-{1}={2}\n", x, y, x - y);
        }
    }

    public class DeriveB : BaseClass
    {
        public new void Subtract(int x,int y)
        {
            Console.WriteLine("In DeriveB:{0}+{1}={2}\n", x, y, x + y);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int x = 10000, y = 1000;
            DeriveA objA = new DeriveA();
            objA.Subtract(x, y);
            DeriveB objB = new DeriveB();
            objB.Subtract(x, y);
            Console.ReadLine();
        }
    }
}
