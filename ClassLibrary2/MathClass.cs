using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class MathClass
    {
        public void AddMethod(int x,int y)
        {
            Console.WriteLine("Add:{0}+{1}={2}\n", x, y, x + y);
        }

        public void SubtractMethod(int x,int y)
        {
            Console.WriteLine("Subtract:{0}-{1}={2}\n", x, y, x - y);
        }

        public void MultiplyMethod(int x,int y)
        {
            Console.WriteLine("Multiply:{0}*{1}={2}\n", x, y, x*y);
        }

        public void DivideMethod(int x,int y)
        {
            Console.WriteLine("Divide: {0}/{1}={2}", x, y, x/y);
        }
    }
}
