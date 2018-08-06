using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp251
{
    public interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();
        void Draw();
    }

    //Multiple interface inheritance OK!
    interface IShape : IDrawable, IPrintable
    {
        int GetNumbersOfSides();
    }


    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public int GetNumbersOfSides()
        {
            return 4;
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    class Square : IShape
    {
        void IDrawable.Draw()
        {
            Console.WriteLine("Draw to screen");
        }

        void IPrintable.Draw()
        {
            Console.WriteLine("Draw to printer...");
        }

        int IShape.GetNumbersOfSides()
        {
            return 4;
        }

        void IPrintable.Print()
        {
            Console.WriteLine("Print to screen");
        }
    }
    public interface IAdvancedDraw:IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }

    public class BitmapImage : IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Drawing....");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box...");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawing upside down");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Iterate over an array of items.
            int[] myArrayOfInts = { 10, 20, 30, 40 };

            foreach(int i in myArrayOfInts)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
