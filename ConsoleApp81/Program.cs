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

            My3DShapes.Circle c3 = new My3DShapes.Circle();
            My3DShapes.Hexagon h3 = new My3DShapes.Hexagon();
            My3DShapes.Square s3 = new My3DShapes.Square();
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

namespace My3DShapes
{
    //3D Circle class.
    public class Circle
    {
        public Circle()
        {
            Console.WriteLine("This is the 3D Circle!\n");
        }

    }
    public class Hexagon
    {
        public Hexagon()
        {
            Console.WriteLine("This is the 3D Hexagon!\n");
        }
    }

    public class Square
    {
        public Square()
        {
            Console.WriteLine("This is the 3D Square!\n");
        }
    }
}


