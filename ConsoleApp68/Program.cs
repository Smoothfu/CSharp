using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp68
{
    class Program
    {
        static void Main(string[] args)
        {
            LambdaExpressionSyntax();
            Console.ReadLine();
        }

        static void LambdaExpressionSyntax()
        {
            //Make a list of integers.
            List<int> intList = new List<int>();
            intList.AddRange(new int[] { 20, 12, 324, 334, 34, 3890, 45, 7875, 75777, 56457, 4575, 5784, 43789332, 3238, 434678, 89232, 324136 });

            //C# lambda expression.
            List<int> evenNumbers = intList.FindAll(x => (x % 2) == 0);

            Console.WriteLine("\nHere are your even numbers: \n");
            foreach(int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
        }

        static void DeclareImplicitVars()
        {
            //Implicit typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time,marches on...";

            //print out the underlying type.
            Console.WriteLine("myInt is a:{0}\n", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}\n", myBool.GetType().Name);
            Console.WriteLine("myString is a:{0}\n", myString.GetType().Name);
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("X:{0},Y:{0}", X, Y);
        }
    }


    public class Rectangle : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public override string ToString()
        {
            return string.Format("TopLeft:{0},BottomRight:{1}\n", TopLeft, BottomRight);
        }
    }
}
