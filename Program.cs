using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp352
{
    class Program
    {
        delegate void AddDel(int x, int y);
        static void Main(string[] args)
        {
            int x = 345667456, y = 456567456;
            AddDel addDel = new AddDel(AddMethod);
            addDel.BeginInvoke(x, y, AddDelCallBack, "This is the AddDel BeginInvoke async state");
            Console.ReadLine();
        }

        private static void AddDelCallBack(IAsyncResult ar)
        {
            var waitToCompleted=ar.AsyncWaitHandle;
            Console.WriteLine(waitToCompleted);
            var result = ar.ToString();
            Console.WriteLine(result);
            Console.WriteLine(ar.AsyncState);
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}");
        }
    }
}
