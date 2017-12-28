using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp66
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            Console.WriteLine("*****Calling method with unsafe code*****");

            //Values for swap.
            int i = 10, j = 20;

            //Swap values "safely."
            Console.WriteLine("\n*****Safe swap*****\n");
            Console.WriteLine("Values before safe swap: i={0},j={1}\n", i, j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i={0},j={1}\n", i, j);

            //Swap values "unsafely."
            Console.WriteLine("\n*****Unsafe swap*****\n");
            Console.WriteLine("Values before unsafe swap: i={0},j={1}\n", i, j);
            unsafe
            {
                UnsafeSwap(&i, &j);
            }

            Console.WriteLine("Values after unsafe swap:i={0},j={1}\n", i, j);
            Console.ReadLine();
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of :{0}\n", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}\n", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString()=={0}\n", obj.ToString());
            Console.WriteLine("obj.GetHashCode()=={0}\n", obj.GetHashCode());
            Console.WriteLine();
        }

        unsafe static void SquareIntPointer(int* myIntPointer)
        {
            //Square the value just for a test.
            *myIntPointer *= *myIntPointer;
        }

        unsafe static void PrintValueAndAddress()
        {
            int myInt;

            //define an int pointer, and assign it the address of myInt.
            int* pointerToMyInt = &myInt;

            //Assign value of myInt using pointer indirection.
            *pointerToMyInt = 123;

            //Print some stats.
            Console.WriteLine("Value of myInt {0}\n", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&pointerToMyInt);
        }

        unsafe public static void UnsafeSwap(int* i,int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwap(ref int i,ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }

    //This entire structure is "unsafe" and can be used only in an unsafe context.
    unsafe struct Node
    {
        public int Value;
        public Node* Left;
        public Node* Right;
    }

    //The struct is safe,but the Node2* members are not. Technically,you may access "Value" from outside an 
    //unsafe context,but not "Left" and "Right"
    public struct Node2
    {
        public int Value;

        //Thes can be accessed only in an unsafe context!
        public unsafe Node2* Left;
        public unsafe Node2* Right;

    }
}
