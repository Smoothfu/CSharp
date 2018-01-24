using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace ConsoleApp90
{
    class Program
    {

        //总收入
        public static float money = 0;
        private static object lockObj = new object();
        static void Main(string[] args)
        {
            //最多5个线程
            ThreadPool.SetMaxThreads(5, 5);
            lock(lockObj)
            {
                for (int i = 0; i < 60; i++)
                {
                    ThreadPool.QueueUserWorkItem(CalculateSalary, 5000);
                }
            }
            
            Thread.Sleep(1000);

            MessageBox.Show(money.ToString());
            Console.ReadLine();
        }

        private static void CalculateSalary(object mny)
        {
            money += int.Parse(mny.ToString());
            Console.WriteLine("The money parameter is :{0}\n", money.ToString());
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }

        static void PrintTime(object obj)
        {
            Console.WriteLine("Time is :{0}, Param is :{1}\n", DateTime.Now.ToLongTimeString(),obj.ToString());
        }
    }

    [Synchronization]
    public class Printer:ContextBoundObject
    {

        public void PrintNumbers()
        {

            //Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);

            //Print out numbers
            Console.WriteLine("Your numbers:");
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(5));
                Console.Write("{0},", i);
            }
            Console.WriteLine("\n\n");
        }
    }
}
