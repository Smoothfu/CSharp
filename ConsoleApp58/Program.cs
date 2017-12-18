using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    public delegate void MathAlgorithmDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            MathClass mathObj = new MathClass();
            MathAlgorithmDel AddDel = mathObj.AddMethod;
            AddDel(10, 20);
            MathAlgorithmDel SubtractDel = mathObj.SubtractMethod;
            SubtractDel(10, 20);
            Console.ReadLine();
        }
    }

    public class MathClass
    {
        public void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public void SubtractMethod(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }
    }
}
