using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace ConsoleApp65
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Extending Interface Compatible Types*****\n");

            //System.Array implements IEnumerable!
            string[] data = { "Wow","this","is","sort","of","annoying","but","in","a","weird","way","fun!"};

            data.PrintDataAndBeep();

            Console.WriteLine("\n\n\n\n");

            //List<T> implements IEnumerable!
            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();

            Console.ReadLine();
        }
    }

    static class MyExtensions
    {
        //This method allows any object to display the assembly it is defined in 
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here:=>{1}\n\n", obj.GetType().Name,
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        //This method allows any integer to reverse its digits.
        //For example,56 would return 65.
        public static int ReverseDigits(this int i)
        {
            //Translate int into a string, and then get all the characters.
            char[] digits = i.ToString().ToCharArray();

            //Now reverse items in the array.
            Array.Reverse(digits);

            //put back into string.
            string newDigits = new string(digits);

            //Finally,return the modified string back as an int.
            return int.Parse(newDigits);
        }
    }

    static class AnnoyingExtensions
    {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach(var item in iterator)
            {
                Console.WriteLine(item+"\n");
                Console.Beep();
            }
        }
    }
}
