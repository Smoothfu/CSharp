using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    //This delegate can point to any method,taking two integers and returning an integer.
    public delegate int BinaryOp(int x, int y);

    //This class contains methods BinaryOp will point to.
    public class SimpleMath
    {
        public  int Add(int x,int y)
        {
            return x + y;
        }

        public static int Subtract(int x,int y)
        {
            return x - y;
        }

        public static void DisplayDelegateInfo(Delegate delObj)
        {
            //Print the names of each member in the delegate's invocation list.
            foreach(Delegate del in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name:{0}", del.Method);
                Console.WriteLine("Type Name:{0}", del.Target);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Simple Delegate Example*****\n");

            //.NET delegates can also point to instance methods as well.
            SimpleMath m = new SimpleMath();
            BinaryOp b = new BinaryOp(m.Add);

            //Show information about this object.
            SimpleMath.DisplayDelegateInfo(b);
            Console.WriteLine("10+10 is {0}", b(10, 10));
            Console.ReadLine();
        }
    } 
}
