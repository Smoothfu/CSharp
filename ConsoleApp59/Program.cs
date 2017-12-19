using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Simple Delegate Example*****\n");

            //Create a BinaryOp delegate object that 'points to ' SimpleMath.Add().

            BinaryOp b = new BinaryOp(SimpleMath.Add);

            //Invoke Add() method indirectly using delegate object.
            Console.WriteLine("10+10 is {0}", b.Invoke(10, 10));
            Console.ReadLine();
        }
    }

    //This delegate can point to any method,
    //taking two integers and returning an integer.

    public delegate int BinaryOp(int x, int y);

    //This class contains methods BinaryOp will point to.

    public class SimpleMath
    {
        public static int Add(int x,int y)
        {
            return x + y;
        }

        public static int Subtract(int x,int y)
        {
            return x - y;
        }
    }
}
