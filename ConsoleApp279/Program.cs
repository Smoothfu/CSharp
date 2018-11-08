using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp279
{
    class Program
    {
        delegate void MathDel(int x, int y);
        delegate void StringDel(string str);
        static void Main(string[] args)
        {
            int x = 10, y = 20;

            //Instantiate the delegate using an annoymous method.
            StringDel strDel = delegate (string str)
              {
                  Console.WriteLine("This string is {0}\n", str);
              };
            strDel("Annoymous methods"); 
            Console.ReadLine();

        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
