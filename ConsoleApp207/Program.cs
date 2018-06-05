﻿using System;
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
            string str = "This is the first string";
            string str2 = str;
            str = "This is the updated string.";
            Console.WriteLine(str);
            Console.WriteLine(str2);
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

       public static  Point operator +(Point X,Point Y)
        {
            int zXCoord = X.XCoord + Y.YCoord;
            int zYCoord = X.YCoord + Y.YCoord;

            Point Z = new Point(zXCoord, zYCoord);
            return Z;
        }

        public override string ToString()
        {
            return string.Format("X:{0},Y:{1}\n", XCoord, YCoord);
        }
    }
}
