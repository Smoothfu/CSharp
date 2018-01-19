using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp86
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchnorous Delegate Review*****\n");

            //Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            //Invoke Add() in a synchronous manner.
            BinaryOp bo = new BinaryOp(Add);
            int answer = bo(10, 10);

            //These lines will not execute until the Add() method has completed.
            Console.WriteLine("Doing more work in Main()!\n");
            Console.WriteLine("10+10 is {0}\n", answer);
            Console.ReadLine();
        }

        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Pause to sumulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
