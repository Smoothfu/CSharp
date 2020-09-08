using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates.Dels;
namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            DelDemo();
            Console.ReadLine();
        }

        static void DelDemo()
        {
            DelDemo demo = new DelDemo();
            PrintMsgDel printDel = demo.PrintTime;
            printDel(null);
        }
    }
}
