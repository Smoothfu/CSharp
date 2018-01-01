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
            AggregateOps();
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

        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2, 23, 34.2, 7, 9.2, -4, 2, 32, 21, 32.1, 23.2, 13.2 };

            //various aggregation examples.
            Console.WriteLine("Max temp:{0}\n", (from t in winterTemps select t).Max());

            Console.WriteLine("Min temp:{0}\n", (from t in winterTemps select t).Min());

            Console.WriteLine("Average temp:{0}\n", (from t in winterTemps select t).Average());

            Console.WriteLine("Sum of all temps:{0}", (from t in winterTemps select t).Sum());
        }
    }
}
