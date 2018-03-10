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

            Console.WriteLine("*****Adding with Thread objects*****\n");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);

            //Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(1000000, 100000000);
            Thread thread = new Thread(new ParameterizedThreadStart(Add));
            thread.Start(ap);

            //Force a wait to let other thread finish.
            Thread.Sleep(5);

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
