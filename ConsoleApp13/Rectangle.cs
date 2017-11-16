using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    [DebugInfo("Fred","30")]
    [DebugInfo("ST","28")]
    class Rectangle
    {
        protected double length;
        protected double width;
        public Rectangle(double l,double w)
        {
            length = l;
            width = w;
        }

        [DebugInfo("FredST","100")]
        public double GetArea()
        {
            return length * width;
        }

        [DebugInfo("FredZTT","1000")]
        public void Display()
        {
            Console.WriteLine("Length: " + length);
            Console.WriteLine("Width: " + width);
            Console.WriteLine("Area: " + GetArea());
        }

    }
}
