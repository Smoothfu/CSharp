using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My3DShapes;

//Resolve the ambiguity using a custom alias.
using The3DHexagon = My3DShapes.Hexagon;

namespace ConsoleApp76
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp76.Hexagon h = new Hexagon();
            ConsoleApp76.Circle c = new Circle();
            ConsoleApp76.Square s = new Square();

            My3DShapes.Circle c3 = new My3DShapes.Circle();
            My3DShapes.Hexagon h3 = new My3DShapes.Hexagon();
            My3DShapes.Square s3 = new My3DShapes.Square();

            //This is really creating a My3DShapes.Hexagon class.
            The3DHexagon h32 = new The3DHexagon();
            Console.ReadLine();
        }
    }     
}

//Another shape-centric namespace.
namespace My3DShapes
{
    //3D Circle class
    public class Circle
    {
        //3D Circle class.
        public Circle()
        {
            Console.WriteLine("This is the constructor of the 3D Circle class!\n");
        }
    }

    //3D Hexagon class.
    public class Hexagon
    {
        public Hexagon()
        {
            Console.WriteLine("The construtor of the 3D Hexagon class!\n");
        }
    }


    //3D Square class.
    public class Square
    {

    }

}

