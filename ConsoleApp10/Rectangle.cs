using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    [DebugInfo(30,"Fred","12/8/2017",Message ="Fred201711152200")]
    [DebugInfo(28,"ST","12/9/2017",Message ="ST201711152201")]
    class Rectangle
    {
        //member variables
        protected double length;
        protected double width;
        public Rectangle(double l,double w)
        {
            length = l;
            width = w;
        }

        [DebugInfo(100,"FredST","19/10/2018",Message ="Get the area")]
        public double GetArea()
        {
            return length * width;
        }

        [DebugInfo(101,"ST","19/10/2200")]
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
}
