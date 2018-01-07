using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace ConsoleApp77
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****C# CarLibrary Client App*****\n");

            //Make a sports car.
            SportCar Benz = new SportCar("Benz", 100, 20);
            Benz.TurboBoost();

            //Make a minivan.
            MinVan mv = new MinVan();
            mv.TurboBoost();

            Console.WriteLine("Done,Press any key to terminate!\n");
            Console.ReadLine();
        }
    }
}
