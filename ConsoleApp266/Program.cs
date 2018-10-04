using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp266
{ 
    class Program
    {
        static void Main(string[] args)
        {
            //Make an array of string data.
            string[] stringArray = { "First", "Second", "Third" };

            //Show number if items in array using length property.
            Console.WriteLine("This array has {0} items.\n", stringArray.Length);
            Console.WriteLine();

            

            //Display contents using enumerator.
            foreach(string str in stringArray)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            //Reverse the array and print again.
            Array.Reverse(stringArray);
            foreach(string str in stringArray)
            {
                Console.WriteLine("Array Entry:{0}\n", str);
            }

            Console.ReadLine();
        }

        static void SimpleBoxUnboxOperation()
        {
            //Make a ValueType (int) variable.
            int myInt = 25;

            //Box the int into an object reference.
            object boxedInt = myInt;
        }
    } 
}
