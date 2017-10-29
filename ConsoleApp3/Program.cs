using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
       static bool isContinuingDoing = true;
        static void Main(string[] args)
        {
            int x = 2435435, y = 2, z = 20;
           

            Thread thread = new Thread(() =>
            {
                Add(x, y, z);
                Subtract(x, y, z);
            });
            thread.Start();

            thread.Join();

            if (thread.ThreadState == ThreadState.Stopped)
            {
                isContinuingDoing = false;
            }

            while (isContinuingDoing)
            {
                Console.WriteLine("This is main thread " + DateTime.Now.ToString("yyyy-MM-dd:HHmmssfff"));
            }            

            Console.ReadLine();
        }

        static void Add(int x,int y,int z)
        {
            Console.WriteLine("{0}+{1}+{2}={3}", x, y, z, x + y + z);
        }

        static void Subtract(int x,int y,int z)
        {
            Console.WriteLine("{0}-{1}-{2}={3}", x, y, z, x - y - z);
        }
    }
}
