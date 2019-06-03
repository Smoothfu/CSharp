using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp351
{
    delegate void MyDel();

    delegate void AddDel (int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100, y = 1000000;
            AddDel addDel = new AddDel(AddMethod);
            addDel.BeginInvoke(x, y, AddCallback, "This the begin invoke last parameter");
            Console.ReadLine();
        }

        private static void AddCallback(IAsyncResult ar)
        {
            var iasynResult = ar.AsyncState;
            Console.WriteLine(iasynResult.ToString());
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}");
        }
        private static void DelCallback(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState);
        }

        static void MyMethod()
        {
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHMMssffff")};");
        }
    }
}
