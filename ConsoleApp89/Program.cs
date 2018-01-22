using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp89
{
    class Program
    {
        //Be sure to import the System.Threading namespace.
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            printer.PrintNumbers();
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
                Console.WriteLine("{0}\t", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine("\n\n\n");
        }
    }
}
