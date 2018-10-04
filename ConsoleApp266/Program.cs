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
            List<int> intList = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            intList.ForEach(x =>
            {
                Console.WriteLine(x);
            });
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
    }
}
