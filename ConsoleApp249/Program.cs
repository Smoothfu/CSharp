using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp249
{
   //Multiple inheritance for interface types is a-okay
   interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();

        //--note possible name clash here!
        void Draw();
    }

    //Multiple interface inheritance ok.
    interface IShape:IDrawable,IPrintable
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
            Console.WriteLine("Draw to screen!");
        }

        void IPrintable.Draw()
        {
            Console.WriteLine("Draw to printer!");
        }

        int IShape.GetNumbersOfSides()
        {
            return 4;
        }

        void IPrintable.Print()
        {
            Console.WriteLine("IPrintable print.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            //Iterate over an array of items/
            int[] intArr = { 10, 20, 30, 40 };
            foreach(int ia in intArr)
            {
                Console.WriteLine(ia);
            }
            Console.ReadLine();
        }
    }
}
