using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp208
{
    class Program
    {
        static void Main(string[] args)
        {
            Point pointA = new Point(100000, 200000);
            Console.WriteLine("pointA:{0}\n", pointA.ToString());

            Point pointB = new Point(2453453, 24343423);
            Console.WriteLine("pointB:{0}\n", pointB.ToString());

            Point pointC = pointA + pointB;
            Console.WriteLine("pointC:{0}\n",pointC);
            Console.ReadLine();
        }
    }

    public class Point
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public Point(int xCoord,int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public override string ToString()
        {
            return string.Format("X:{0},Y:{1}\n", XCoord, YCoord);
        }

        public static Point operator+(Point pointA,Point pointB)
        {
            int zXCoord = pointA.XCoord + pointB.XCoord;
            int zYCoord = pointA.YCoord + pointB.YCoord;
            return new Point(zXCoord, zYCoord);
        }
    }
}
