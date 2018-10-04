using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp266
{
    class MyGenericClass<T> where T:class
    {
        private T genericMemberVariable;
        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public T generateMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type:{0},value:{1}\n", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type:{0},value:{1}\n", typeof(T).ToString(), genericMemberVariable);
            return genericMemberVariable;
        }

        public T genericMethod<U>(T genericParameter,U anotherGenericType) where U:struct
        {
            Console.WriteLine("Generic Parameter of type {0},value {1}\n", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return value of type {0},value {1}\n", typeof(T).ToString(), genericMemberVariable);
            return genericMemberVariable;
        }

        public T genericProperty { get; set; }
    }
    class Program
    {
        public delegate T Add<T>(T param1, T param2);
        static void Main(string[] args)
        {
            SortedList<int, string> intSortedList = new SortedList<int, string>();
            intSortedList.Add(1, "One");
            intSortedList.Add(2, "Two");
            intSortedList.Add(3, "Three");
            intSortedList.Add(4, "Four");
            intSortedList.Add(5, "Five");

            SortedList<string, int> stringSortedList = new SortedList<string, int>();
            stringSortedList.Add("One", 1);
            stringSortedList.Add("Two", 2);
            stringSortedList.Add("Three", 3);
            stringSortedList.Add("Four", 4);


            SortedList<double, int?> doubleSortedList = new SortedList<double, int?>();
            doubleSortedList.Add(1.4, 100);
            doubleSortedList.Add(3.5, 200);
            doubleSortedList.Add(3.9, 500);
            doubleSortedList.Add(3.8, null);
            doubleSortedList.Add(3.81111111111111111, null);

            foreach(double d in doubleSortedList.Keys)
            {
                Console.WriteLine(d);
            }
            Console.ReadLine();             
        }

        public static int AddNumber(int val1,int val2)
        {
            return val1 + val2;
        }

        public static string Concate(string firstStr,string secondStr)
        {
            return firstStr + secondStr;
        }

        static bool IsPositiveInt(int i)
        {
            return i > 0;
        }
    }
}
