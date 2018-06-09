using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;


namespace ConsoleApp216
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static int intVal = 100;
        private static int newVal;
        static void Main(string[] args)
        {
            //Thread[] allThreads = new Thread[10];
            //Printer p = new Printer();

            //for(int i=0;i<10;i++)
            //{
            //    allThreads[i] = new Thread(p.PrintNumbers);
            //}

            //allThreads.All(x =>
            //{
            //    x.Start();
            //    return true;
            //});


            Console.WriteLine("*****Working with Timer type*****\n");

            //Create the delegate for the Timer type.
            TimerCallback timeCB = new TimerCallback(PrintTime);

            //Establish timer settings.
            Timer t = new Timer(
                timeCB,     //The TimerCallback delegate object.
                "Hello from main",       //Any info to pass into the called method null for no info.
                0,          //Amount of time to wait before starting 
                1000);      //Interval of time between calls in milliseconds.

            Console.WriteLine("Hit key to terminate");
            Console.ReadLine();
        }

        
        static void PrintTime(object obj)
        {
            Console.WriteLine("Time is :{0},Param is :{1}\n", DateTime.Now.ToLongTimeString(),obj.ToString());
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

    //All method of printer are now thread safe!

    [Synchronization]
    public class Printer:ContextBoundObject
    {      
        public void PrintNumbers()
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
