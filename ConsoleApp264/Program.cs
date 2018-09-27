using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp264
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make an array of string data.
            string[] strArray = { "First", "Second", "Third" };

            //Show number of items in array using Length property.
            Console.WriteLine("This array has {0} items.", strArray.Length);
            Console.WriteLine();


            //Display contents using enumerator.
            foreach(string str in strArray)
            {
                Console.WriteLine("Array Entry: {0}",str);
            }

            Console.WriteLine();

            //Reverse the array and print again.
            Array.Reverse(strArray);
            foreach(string str in strArray)
            {
                Console.WriteLine("Array Entry:{0}.", str);
            }
            Console.ReadLine();
        }
    }
}
