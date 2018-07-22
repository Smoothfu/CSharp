using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp249
{
    //Draw image to a form
    public interface IDrawToForm
    {
        void Draw();
    }

    //Draw to buffer in memory
    public interface IDrawToMemory
    {
        void Draw();
    }

    //Render to the printer
    public interface IDrawToPrinter
    {
        void Draw();
    }

    class OCtagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Draw To Form");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Draw to Memory");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Draw to Printer");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Interface Name clashes*****\n");
            //All of these invocations call the same Draw() method!
            OCtagon octObj = new OCtagon();
            ((IDrawToForm)octObj).Draw();
             

            IDrawToPrinter iftPrinter = octObj as IDrawToPrinter;
            if (iftPrinter != null)
            {
                iftPrinter.Draw();
            }

            IDrawToMemory itfMemory = octObj as IDrawToMemory;
            if (itfMemory != null)
            {
                itfMemory.Draw();
            }

            Console.ReadLine();
        }
    }
}
