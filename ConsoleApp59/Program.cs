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
            Console.WriteLine("10+10 is {0}\n\n\n\n", b.Invoke(10, 10));

            DisplayDelegateInfo(b);
            Console.ReadLine();
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            //Print the names of each member in the delegate's invocation list.
            foreach(Delegate del in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name:{0}", del.Method);
                Console.WriteLine("Type Name:{0}", del.Target);
            }
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

        public static int SquareNumber(int a)
        {
            return a * a;
        }
    }
}
