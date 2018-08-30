using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp257
{
    interface IA
    {
        void AddMethod(int x, int y);
    }

    interface IB
    {
        void AddMethod(int x, int y);
    }

    class AddClass : IA, IB
    {
        void IA.AddMethod(int x, int y)
        {
            Console.WriteLine("In IA:{0}+{1}={2}\n", x, y, x + y);
        }

        void IB.AddMethod(int x, int y)
        {
            Console.WriteLine("In IB:{0}+{1}={2}\n", x, y, x + y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AddClass obj = new AddClass();
            IA objA = obj as IA;
            if(objA!=null)
            {
                objA.AddMethod(1000, 1000000);
            }

            IB objB = obj as IB;
            if(objB!=null)
            {
                objB.AddMethod(100000, 24354000);
            }
            Console.ReadLine();
        }
    }
}
