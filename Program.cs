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
            int[] arr = new int[10000];
            arr = Enumerable.Range(1, 10000).ToArray();
            Parallel.ForEach(arr, x =>
            {
                Console.Write(x + "\t");
            });
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
