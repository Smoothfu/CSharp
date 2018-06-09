using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace ConsoleApp216
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****The Amazing Thread App*****\n");
            Console.WriteLine("Do you want [1] or [2] threads?");
            string threadCount = Console.ReadLine();

            //Name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";


            //Display Thread info.
            Console.WriteLine("->{0} is executing Main()!\n", Thread.CurrentThread.Name);

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
                    Console.WriteLine("I don't know you want ... you get 1 thread.\n");
                    goto case "1";
            }

            //Do some additional work.

            MessageBox.Show("I'm busy!", "Work on main thread...");

            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

    }

    public class Printer
    {
        public void PrintNumbers()
        {
            //Display Thread Info
            Console.WriteLine("->{0} is executing PrintNumbers()\n",Thread.CurrentThread.Name);

            //Print out numbers
            Console.Write("Your numbers:\n");
            for(int i=0;i<10;i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();

        }
    }
}
