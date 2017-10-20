using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp79
{
    public class MyGenericArray<T>
    {
        private T[] array;
        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }

        public T getItem(int index)
        {
            return array[index];
        }

        public void setItem(int index, T value)
        {
            array[index] = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //声明一个整型数组
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);
            //设置值
            for (int i = 0; i < 5; i++)
            {
                intArray.setItem(i, i * 5);
            }

            //获取值
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(intArray.getItem(i));
            }

            Console.WriteLine();

            //声明一个字符数组
            MyGenericArray<Char> charArray = new MyGenericArray<Char>(5);

            //设置值
            for (int i = 0; i < 5; i++)
            {
                charArray.setItem(i, (char)(i + 97));
            }

            //获取值
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(charArray.getItem(i));
            }
            Console.ReadLine();
        }
    }
}
 