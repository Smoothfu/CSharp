using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp145
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use an Action delegate and named method
            Task task1 = new Task(new Action(PrintMessage));

            //Uase an anonymous delegate.
            Task task2 = new Task(delegate { PrintMessage(); });

            //Use a lambda expression and a named method
            Task task3 = new Task(() => PrintMessage());

            //Use a Lambda expression and an anonymous method;.
            Task task4 = new Task(() =>
              {
                  PrintMessage();
              });

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            Console.WriteLine("Main method complete.Press <Enter> to finish.");
            
            Console.ReadLine();
        }

        static void Add(int x,int y,int z)
        {
            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }

        private static void PrintMessage()
        {
            Console.WriteLine("The world is fair!\n");
        }
    }
}
