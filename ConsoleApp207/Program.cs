using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
namespace ConsoleApp207
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(100, 200);
            Point B = new Point(300, 400);
            Point C = PointExtension.TwoPointsAdd(A, B);
            Console.WriteLine(C);
            Console.ReadLine();
        }
    }

  public class Point
    {
        public Point(int x)
        {

        }

        public Point(int x,int y,int z)
        {

        }
        public int Age = 27;
        public string Name = "WYQ";
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

    public static class PointExtension
    {
        public static Point TwoPointsAdd(this Point x,Point y)
        {
            return new Point(x.XCoord + y.XCoord, x.YCoord + y.YCoord);
        }
    }

     
}
