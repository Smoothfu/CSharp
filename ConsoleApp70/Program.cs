using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp70
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayConcatNoDups();
            Console.ReadLine();
        }

        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carContact = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            //Prints:
            foreach(string str in carContact.Distinct())
            {
                Console.WriteLine(str + "\n");
            }
        }
    }
}
