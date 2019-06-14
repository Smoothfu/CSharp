using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp361
{
    class Program
    {
        delegate string MathDel(int x, int y);

        static void Main(string[] args)
        {
            MathDel addDel = Add;
            IAsyncResult asyncResult = addDel.BeginInvoke(10, 10, AddCallBack, "This parameter can be omitted");
            string addResult = addDel.EndInvoke(asyncResult);
            Console.WriteLine(addResult);
            Console.ReadLine();
        }

        private static void AddCallBack(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState);
        }

        static string  Add(int x,int y)
        {
            return string.Format($"The sum of {x} and {y} is {x + y}");
        }
    }
}
