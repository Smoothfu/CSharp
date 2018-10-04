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
            //Declaring an int array.
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            //setting values
            for(int i=0;i<5;i++)
            {
                intArray.SetItem(i, i * i);
            }

            //Retrieving the values/
            for(int i=0;i<5;i++)
            {
                Console.WriteLine(intArray.GetItem(i));
            }

            Console.WriteLine();

            //Declaring a character array.
            MyGenericArray<char> charArray = new MyGenericArray<char>(10);

            //setting values/
            for(int i=0;i<10;i++)
            {
                charArray.SetItem(i, (char)(i + 97));
            }

            //retrieving the values/
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(charArray.GetItem(i));
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

    public class MyGenericArray<T>
    {
        private T[] array;
        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }

        public T GetItem(int index)
        {
            return array[index];
        }

        public void SetItem(int index,T value)
        {
            array[index] = value;
        }
    }
}
