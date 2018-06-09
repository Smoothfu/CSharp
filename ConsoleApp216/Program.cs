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
            Console.WriteLine("******Adding with thread objects*****");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);

            //Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(1000, 2000);
            Thread thread = new Thread(new ParameterizedThreadStart(Add));

            thread.Start(ap);

            //Force a wait to let other thread finish.
            Thread.Sleep(5);
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
