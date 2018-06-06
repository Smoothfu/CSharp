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
            Task task = new Task(() =>
            {
                Point pA = new Point(34254314, 2342343);
                Console.WriteLine("pA:{0}\n", pA.ToString());
            });
            task.Start();

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
