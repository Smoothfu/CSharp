using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp69
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make an anonymous type that is composed of another.
            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "BlacK", Make = "Mercedes Benz", CurrentSpeed = 55 },
                Price = 34000
            };

            Console.WriteLine(purchaseItem.ToString());
            Console.ReadLine();
        }

        static void DeclareImplicitVars()
        {
            //Implicit typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time,marches on...";

            //Print out the underlying type.
            Console.WriteLine("myInt is a: {0}\n", myInt.GetType().Name);
            Console.WriteLine("myBool is a :{0}\n", myInt.GetType().Name);
            Console.WriteLine("myString is a:{0}\n", myString.GetType().Name);           
        }

        static void LambdaExpressionSyntax()
        {
            //Make a list of integers.
            List<int> intList = new List<int>();

            intList.AddRange(new int[] { 20, 32, 434, 234, 53, 45231, 54323, 343, 32809, 231, 3521359, 342338, 4534243, 42423428, 789823412, 4234218 });


            //C# lambda expression.
            List<int> evenNumbers = intList.FindAll(x => (x % 2) == 0);

            Console.WriteLine("Here are your even numbers: ");

            foreach(int evenNumber in evenNumbers)
            {
                Console.Write("{0}  \t", evenNumber);
            }
            Console.ReadLine();

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

    public class Rectangle:IEnumerable
    {
        public Point LeftTop { get; set; }
        public Point RightBottom { get; set; }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format("LeftTop: {0},RightBottom:{1}\n", LeftTop, RightBottom);
        }
    }

    static class ObjectExtensions
    {
        //Define an extension method to System.Object
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("lives here:->{0}\n",  Assembly.GetAssembly(obj.GetType()));
        }
    }
}
