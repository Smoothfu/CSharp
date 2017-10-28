using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        private static void ThreadExample()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " i= " + i);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " has finished");
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread is here";

            Thread newThread = new Thread(new ThreadStart(ThreadExample));
            newThread.Name = "New Thread Name";

            for(int j=0;j<20;j++)
            {
                if(j==10)
                {
                    newThread.Start();
                    newThread.Join();
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " j= " + j);
                }
            }
            Console.ReadLine();
        }
    }
}
