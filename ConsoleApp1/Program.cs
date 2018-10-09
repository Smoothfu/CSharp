using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 34546646, y = 456735676;
            MathServiceReference.MathServciceClient client = new MathServiceReference.MathServciceClient();
            int result = client.AddMethod(x,y);
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            Console.ReadLine();
        }
    }
}
