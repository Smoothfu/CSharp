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
            SportCar sc = new SportCar("BENZ", 100, 50);
            sc.TurboBoost();

            MinVan van = new MinVan("Turtle", 100, 20);
            van.TurboBoost();
            Console.ReadLine();
        }
    }
}
