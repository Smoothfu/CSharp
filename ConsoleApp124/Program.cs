using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp124
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printerObj = new Printer();
            printerObj.PrintNumbers();
            Console.ReadLine();
        }
    }

    public class Printer
    {
        object threadLock = new object();
        public void PrintNumbers()
        {
            Monitor.Enter(threadLock);

            try
            {
                //Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()!\n", Thread.CurrentThread.Name);

                //Print out numbers.
                Console.Write("Your numbers:\n");
                for(int i=0;i<10;i++)
                {
                    Console.Write(i + "\t");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}
