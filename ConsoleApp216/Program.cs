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
        private static int intVal = 100;
        private static int newVal;
        static void Main(string[] args)
        {
            AddOne();
            Console.WriteLine(newVal);             
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

        static void AddOne()
        {
            newVal = Interlocked.Increment(ref intVal);
        }

    }

    public class Printer
    {
        //Lock token.
        private object threadLock = new object();
        private static int intVal;
        public void PrintNumbers()
        {
            Monitor.Enter(threadLock);
            try
            {
                //Display Thread Info
                Console.WriteLine("->{0} is executing PrintNumbers()\n", Thread.CurrentThread.Name);

                //Print out numbers
                Console.Write("Your numbers:\n");
                for (int i = 0; i < 10; i++)
                {
                    //Put thread to sleep for a random amount of time.
                    Random rnd = new Random();
                    Thread.Sleep(1000 * rnd.Next(5));
                    Console.Write("{0}\t", i);
                }
            }
            finally
            {
                Monitor.Exit(threadLock);
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
