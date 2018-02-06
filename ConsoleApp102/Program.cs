using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp102
{
    public delegate int BinaryOp(int x, int y);
    public delegate void SubtractDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            SubtractDel del = new SubtractDel(Subtract);
            del(10, 20);

            Console.ReadLine();
        }

        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }

        static void Subtract(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}\n", x, y, x - y);
        }
    }
}
