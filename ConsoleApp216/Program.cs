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

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        static void Add(object data)
        {
            var addParam = data as AddParams;
            if(addParam!=null)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);

                AddParams ap = (AddParams)data;
                Console.WriteLine("{0}+{1}={2}\n", ap.a, ap.b, ap.a + ap.b);
            }


            //Tell other thread we are done.
            waitHandle.Set();
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
