using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperCar sc = new SuperCar("BENZ",50.0,100.0);
            Console.WriteLine(sc);
            sc.Turbust();

            MiniVan mv = new MiniVan("MiniCooper",25.0,50.0);
            Console.WriteLine(mv);
            mv.Turbust();

            Console.ReadLine();
        }
    }
}
