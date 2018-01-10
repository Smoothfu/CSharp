using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp81
{
    class Program
    {
        static void Main(string[] args)
        {
            Hexagon h = new Hexagon();
            Circle c = new Circle();
            Square s = new Square();
            Console.ReadLine();
        }
    }

    //Circle class
    public class Circle
    {
        /*Interesting members...*/
        public Circle()
        {
            Console.WriteLine("This is Circle!\n");
        }
    }

    //Hexagon class
    public class Hexagon
    {
        /* More interesting members...*/
        public Hexagon()
        {
            Console.WriteLine("This is Hexagon!\n");
        }        
     }

    //Square class
    public class Square
    {
        /*Even more interesting members...*/

        public Square()
        {
            Console.WriteLine("This is Square!\n");
        }
    }
}
