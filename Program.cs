using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp351
{
    delegate void MyDel();

    delegate void AddDel (int x, int y);
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        static volatile bool isStop = false;
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            DateTime endDt = dt.AddSeconds(5);
            while(DateTime.Now<endDt)
            {
                Timer taskTimer = new Timer(TaskCancellation, "This is the Timer", 0, 1000);
            }
            isStop = true;
            Console.ReadLine();
        }

        static void TaskCancellation(object obj)
        {
            if (isStop)
            {
                return;
            }
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")};");
            Thread.Sleep(1000);
        }
        private static void AddCallback(IAsyncResult ar)
        {
            var iasynResult = ar.AsyncState;
            Console.WriteLine(iasynResult.ToString());
        }
        static void AddMethod(int x, int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}");
        }
        private static void DelCallback(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState);
        }
        static void MyMethod()
        {
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")};");
        }
    }
}
