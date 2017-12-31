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
            QueryOverInts();            
            Console.ReadLine();
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100,54566246,674567,562456,567536745, 1, 2, 3, 4, 5, 3, 23, 232, 32345, 546, 5667, 56498 };

            //Print only items which is more than 100000
            IEnumerable<int> subset = from i in numbers where i > 100000 select i ;
            foreach(int i in subset)
            {
                Console.WriteLine("Item:{0}\n", i);
            }
            ReflectOverQueryResults(subset);
        }

        static void QueryOverStrings()
        {
            //Assume we have an array of strings.
            string[] currentBooks = { "C#", "Data Structure", "SOA", "Operating System", "Database", "NetWork", "AI", "Big Data" };

            IEnumerable<string> subset = from book in currentBooks
                                where book.Length > 1
                                select book;
            foreach(var book in subset)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\n\n\nRelecting over a LINQ Result Set*****\n");
            ReflectOverQueryResults(subset);
        }

        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("*****Info about your query*****\n");
            Console.WriteLine("resultSet is type:{0}\n", resultSet.GetType().Name);
            Console.WriteLine("resultSet location:{0}\n", resultSet.GetType().Assembly.GetName().Name);
        }

        static void QueryOverStringsLongHand()
        {
            //Assume we have an array of strings.
            string[] booksArray = new string[] { "C#", "Data Structure", "SOA", "Operating System", "Database", "NetWork", "AI", "Big Data", "Cloud" };
            string[] bookArr = new string[booksArray.Length];

            for(int i=0;i<booksArray.Length;i++)
            {
                bookArr[i] = booksArray[i];
            }

            //Now sort them.
            Array.Sort(bookArr);

            //Print out the results.
            foreach(string book in bookArr)
            {
                if(book!=null && !string.IsNullOrEmpty(book))
                {
                    Console.WriteLine(book+"\n");
                }
            }
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
