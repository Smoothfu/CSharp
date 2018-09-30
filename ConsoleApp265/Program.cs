using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp265
{
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
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring an int array.
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            //Setting values.
            for(int i=0;i<5;i++)
            {
                intArray.SetItem(i, i * 5);
            }

            //retrieving the values.
            for(int i=0;i<5;i++)
            {
                Console.WriteLine(intArray.GetItem(i));
            }

            Console.WriteLine();

            //Declaring a character array.
            MyGenericArray<char> charArray = new MyGenericArray<char>(5);

            //setting values
            for(int i=0;i<5;i++)
            {
                charArray.SetItem(i, (char)(i + 97));
            }

            //retrieving the values.
            for(int i=0;i<5;i++)
            {
                Console.WriteLine(charArray.GetItem(i));
            }

            Console.ReadLine();
        }
    }
}
