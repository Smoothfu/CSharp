using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace ConsoleApp81
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****C# CarLibrary Client App*****\n");

            //Make a sport car.
            SportsCar sc = new SportsCar("BENZ", 100, 50);
            sc.TurboBoost();

            //Make a minivan.
            MiniVan mv = new MiniVan();
            mv.TurboBoost();

            Console.WriteLine("Done! Press any key to terminate!");

            Console.ReadLine();
        }
    }
}



