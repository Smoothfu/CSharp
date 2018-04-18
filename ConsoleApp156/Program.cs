using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp156
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Background Threads*****\n");
            Printer objPrinter = new Printer();
            Thread bgThread = new Thread(new ThreadStart(objPrinter.PrintNumbers));

            //This is now a background thread.
            bgThread.IsBackground = true;
            bgThread.Start();
            bgThread.Join();

            if(bgThread.ThreadState==ThreadState.Stopped)
            {
                Console.WriteLine("Finished!\n");
            }
            Console.ReadLine();
        }

        static void Add(object data)
        {
            var addObj = data as AddParams;
            if(addObj!=null)
            {
                Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine("{0}+{1}={2}\n", addObj.a, addObj.b, addObj.a + addObj.b);

                //Tell other thread we are done.
                waitHandle.Set();
            }
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

    public class Printer
    {
        public void PrintNumbers()
        {
            for(int i=0;i<1000;i++)
            {
                Console.WriteLine("Now i is {0} and time is {1}\n", i, DateTime.Now.ToString("yyyyMMdd:HHmmssfff"));
            }
            
        }
    }
}
