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
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Background Threads*****\n");
            Printer p = new Printer();
            Thread bgThread = new Thread(new ThreadStart(p.PrintNumbers));

            //This is now a background thread.
            bgThread.IsBackground = true;
            bgThread.Start();
             
            Console.ReadLine();
        }

        static void Add(object data)
        {
            var addObj = data as AddParams;
            if(addObj==null)
            {
                return;
            }

            if(addObj is AddParams)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)addObj;
                Console.WriteLine("{0}+{1}={2}\n", ap.a, ap.b, ap.a + ap.b); 
            }
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

    class AddParams
    {
        public int a, b;
        public AddParams(int numb1,int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }
}
