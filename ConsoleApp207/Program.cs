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
            Type type = typeof(Point);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.GUID);
            FieldInfo[] fis = type.GetFields();
            foreach(FieldInfo fi in fis)
            {
                Console.WriteLine(fi.Name);
            }

            MethodInfo[] mis = type.GetMethods();
            foreach(MethodInfo mi in mis)
            {
                Console.WriteLine(mi.Name);
            }
            Console.ReadLine();
        }
    }

  public class Point
    {
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

        public static Point operator *(Point x,Point y)
        {
            int zXCoord = x.XCoord * y.XCoord;
            int zYCoord = x.YCoord * y.YCoord;
            return new Point(zXCoord, zYCoord);
        }
    }
}
