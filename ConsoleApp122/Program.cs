using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp122
{
    //A C# delegate type.
    public delegate int BinaryOp(int x, int y);

    delegate int SomeDelegate(int x);
    class Program
    {
        static void Main(string[] args)
        {
            //Create delegate instance
            SomeDelegate sd = SquareNumber;

            //Invoke delegate.
            int result = sd(10);
            Console.WriteLine("Back to Main method!\n");
            Console.WriteLine(result);
 
            Console.ReadLine();
        }         
         
        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(1000);

            return x + y;
        }

        static int SquareNumber(int a)
        {
            Console.WriteLine("SquareNumber Invoked.Processsing...");
            Thread.Sleep(2000);
            return a * a;
        }
    }
}
