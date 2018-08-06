using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp251
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with Object Cloning******\n");

            //Notice Clone() returns a plain object type.
            Point p3 = new Point(100, 100);
            Point p4 = (Point)p3.Clone();

            p4.X = 0;

            //Print each object
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.ReadLine();
        }
    }

    //A class named Point.
    public class Point:ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos,int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public Point()
        {

        }

        public override string ToString()
        {
            return string.Format("X={0},Y={1}", X, Y);
        }

        //Return a copy of the current object.
        public object Clone()
        {
            return new Point(this.X, this.Y);
        }
    }
}
