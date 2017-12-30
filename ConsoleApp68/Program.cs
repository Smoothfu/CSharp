using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp68
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> myListOfRects = new List<Rectangle>
            {
                new Rectangle{TopLeft=new Point{X=10,Y=10},
                BottomRight=new Point{X=200,Y=200}},
                new Rectangle{TopLeft=new Point{X=2,Y=2},
                BottomRight=new Point{X=100,Y=100}},
                new Rectangle{TopLeft=new Point{X=5,Y=5},
                BottomRight=new Point{X=90,Y=75}}
            };

            foreach(var rect in myListOfRects)
            {
                Console.WriteLine(rect + "\n");
            }
            Console.ReadLine();
        }

        static void DeclareImplicitVars()
        {
            //Implicit typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time,marches on...";

            //print out the underlying type.
            Console.WriteLine("myInt is a:{0}\n", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}\n", myBool.GetType().Name);
            Console.WriteLine("myString is a:{0}\n", myString.GetType().Name);
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("X:{0},Y:{0}", X, Y);
        }
    }


    public class Rectangle : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public override string ToString()
        {
            return string.Format("TopLeft:{0},BottomRight:{1}\n", TopLeft, BottomRight);
        }
    }
}
