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
            Console.WriteLine("*****Fun with Extension Methods*****\n");

            //The int has assumed a new identity!
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();

            //So had the dataset!
            DataSet ds = new DataSet();
            ds.DisplayDefiningAssembly();


            //Use new integer functionality.
            Console.WriteLine("Value of myInt:{0}\n", myInt);
            Console.WriteLine("Reversed digits of myInts:{0}\n", myInt.ReverseDigits());

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
}
