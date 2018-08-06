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

            Point p1 = new Point(50, 50);
            Point p2 = p1;
            //p2.X = 0;
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.ReadLine();
        }
    }

    //A class named Point.
    public class Point
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
    }
}
