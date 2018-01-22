using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApp89
{
    class Program
    {
        //Be sure to import the System.Threading namespace.
        static void Main(string[] args)
        {

            Console.WriteLine("*****The Amazing Thread App!*****\n");
            Console.WriteLine("Do you want [1] or [2] threads?\n");

            string threadCount = Console.ReadLine();

            //Name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            //Display Thread info.
            Console.WriteLine("-> {0} is executing Main()!\n", Thread.CurrentThread.Name);

            //Make worker class.
            Printer printer = new Printer();

            switch(threadCount)
            {
                case "2":
                    //Now make the thread.
                    Thread backgroundThread = new Thread(new ThreadStart(printer.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;

                case "1":
                    printer.PrintNumbers();
                    break;

                default:
                    Console.WriteLine("I do not know what you want...you get 1 thread.\n");
                    goto case "1";
            }

            //Do some additional work.
            MessageBox.Show("I am busy!", "Work on main thread...");
            Console.ReadLine();
        }
    }

    public class Printer
    {
        public void PrintNumbers()
        {
            //Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbbers()!\n", Thread.CurrentThread.Name);

            //Print out numbers.
            Console.WriteLine("Your numbers:\n");

            for(int i=0;i<10;i++)
            {
                Console.Write("{0}\t", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine("\n\n\n");
        }
    }
}
