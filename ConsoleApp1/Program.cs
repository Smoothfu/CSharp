using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace ConsoleApp1
{
    class Program
    {
        static int x = 10000, y = 10000;
        static void Main(string[] args)
        {
            MathClass mc = new MathClass();
            mc.AddMethod(x, y);
            mc.SubtractMethod(x, y);
            mc.MultiplyMethod(x, y);
            mc.DivideMethod(x, y);
            Console.ReadLine();
        }
    }
}
