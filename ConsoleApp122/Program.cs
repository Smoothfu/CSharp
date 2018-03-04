using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ConsoleApp122
{
    //A C# delegate type.
    public delegate int BinaryOp(int x, int y);

    delegate int SomeDelegate(int x);
    class Program
    {
        private static bool isDone = false;
        static void Main(string[] args)
        {

            Console.WriteLine("*****The Amazing Thread App*****\n");
            Console.WriteLine("Do you want [1] or [2] threads?");
            string threadCount = Console.ReadLine();

            //Name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            //Display Thread info.
            Console.WriteLine("-> {0} is executing Main()!\n",Thread.CurrentThread.Name);

            //Make worker class.
            Printer p = new Printer();

            switch(threadCount)
            {
                case "2":
                    //Now make the thread.
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;

                case "1":
                    p.PrintNumbers();
                    break;

                default:
                    Console.WriteLine("I don't know what you want ... you get 1 thread.\n");
                    goto case "1";
            }

            //Do some additional work.

            MessageBox.Show("I'm busy!", "Work on main thread...");

            Console.ReadLine();
        }         
         
        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(1000);

            return x + y;
        }

        static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete!\n");

            //Now get the result.
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp bo = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10+10 is {0}.\n", bo.EndInvoke(itfAR));

            //Retrieve the informational object and cast it to string.
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);

            isDone = true;
        }

        static int SquareNumber(int a)
        {
            Console.WriteLine("SquareNumber Invoked.Processsing...");
            Thread.Sleep(2000);
            return a * a;
        }
    }


    public class Printer
    {
        public void PrintNumbers()
        {
            //Display Thread info.
            Console.WriteLine("- >{0} is executing PrintNumbers()! \n",Thread.CurrentThread.Name);


            //Print out numbers.
            Console.WriteLine("Your numbers:\n");
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);
            }

            Console.WriteLine();
        }
    }
}
