using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp259
{
    public struct Number
    {
        private int n;
        public Number(int value)
        {
            n = value;
        }

        public int Value
        {
            get
            {
                return n;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Number))
            {
                return false;
            }
            else
            {
                return n == ((Number)obj).n;
            }
        }

        public override int GetHashCode()
        {
            return n;
        }

        public override string ToString()
        {
            return n.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for(int i=0;i<=9;i++)
            {
                int randomNum = rnd.Next(Int32.MinValue, Int32.MaxValue);
                Number n = new Number(randomNum);
                Console.WriteLine("n={0,12},hash code={1,12}", n, n.GetHashCode());
            }
            Console.ReadLine();
        }
    }
}
