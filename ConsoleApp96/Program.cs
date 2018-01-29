using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp96
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> namesList = new List<string>();
            namesList.Add("Fred");
            namesList.Add("Floomberg");
            namesList.Add("Michael Bloomberg");
            namesList.Add("Bill Gates");
            namesList.Add("Jeff Bezos");
            namesList.Add("Elon Musk");
            namesList.Add("Larry Ellison");
            namesList.Add("Larry Page");
            namesList.Add("Pony Ma");
            namesList.Add("Jack Ma");

          
            //Display the contents of the list using the PrintNames method.
            namesList.ForEach(PrintNames);

            Console.WriteLine("\n\n\n");
            //The following demonstrates the anonymous method feature of C# to 
            //display the contents of the list to the console.
            namesList.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });

            Console.ReadLine();
        }

        private static void PrintNames(string str)
        {
            Console.WriteLine(str);
        }
    }
}
