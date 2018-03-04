using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ConsoleApp122
{
    //A C# delegate type.
    public delegate int BinaryOp(int x, int y);

    delegate int SomeDelegate(int x);
    class Program
    {
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Adding with Thread objects******\n");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(AddParams.Add));
            t.Start(ap);

            //Wait here until you are notified.
            waitHandler.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();
        }

        class AddParams
        {
            public int a, b;
            public AddParams(int numb1, int numb2)
            {
                a = numb1;
                b = numb2;
            }

            public static void Add(object data)
            {
                if (data is AddParams)
                {
                    Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);

                    AddParams ap = (AddParams)data;
                    Console.WriteLine("{0}+{1}={2}\n", ap.a, ap.b, ap.a + ap.b);

                    //Tell other thread we are done

                }

                waitHandler.Set();
                Console.WriteLine("The AddParam thread is over!\n");
            }
        }
    }

    
}
