using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp207
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(100, 200);
            Point B = new Point(300, 400);
            Point C = A - B;
            Console.WriteLine(C);
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
            return string.Format("X:{0},Y:{1}", XCoord, YCoord);
        }

        public static Point operator -(Point x,Point y)
        {
            int zXCoord = x.XCoord - y.XCoord;
            int zYCoord = x.YCoord - y.YCoord;

            return new Point(zXCoord, zYCoord);
        }
    }
}
