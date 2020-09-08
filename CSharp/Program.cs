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
            DelBeginEndInvoke();
            Console.ReadLine();
        }

        static void DelBeginEndInvoke()
        {
            DelDemo demo = new DelDemo();
            MathDel mathDel = demo.Add;
            int x = 1, y = 100000;
            IAsyncResult asyncResult = mathDel.BeginInvoke(x, y, DelCB, "Test this");
            int result = mathDel.EndInvoke(asyncResult);
            Console.WriteLine(result);
        }

        private static void DelCB(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState.ToString());
        }

        static void DelDemo()
        {
            DelDemo demo = new DelDemo();
            PrintMsgDel printDel = demo.PrintTime;
            printDel(null);
        }
    }
}
