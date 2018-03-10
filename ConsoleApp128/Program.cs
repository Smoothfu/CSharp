using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp128
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****The Amazing Thread App*****\n");
            Console.WriteLine("Do you want [1] or [2] threads?\n");
            string threadCount = Console.ReadLine();

            //Name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "PrimaryThread";

            //Display Thread info.
            Console.WriteLine("-> {0} is executing Main()\n", Thread.CurrentThread.Name);

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
                    Console.WriteLine("I don't know what you want...you get 1 thread.\n");
                    goto case "1";

            }

            //Do some additional work.
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
        }
    }

    public class Printer
    {
        public void PrintNumbers()
        {
            //Display Thread info.
            Console.WriteLine("->{0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);

            //Print out numbers.
            Console.WriteLine("Your numbers: ");

            for(int i=0;i<10;i++)
            {
                Console.WriteLine("{0}\n", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
