using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        public void ThreadMethod()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("ThreadMethod :"+ i);
                Thread.Sleep(new TimeSpan(0, 0, 1));
            }
        }

        public void ThreadMethod2()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("ThreadMethod2: " + i);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Before start thread");
            Program obj1 = new Program();
            Program obj2 = new Program();

            Thread thread1 = new Thread(obj1.ThreadMethod);
            Thread thread2 = new Thread(obj2.ThreadMethod);

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Main thread ended");

            Console.ReadLine();
        }   
    }
}
