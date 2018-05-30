using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp196
{
    class Program
    {
        public delegate string   BinaryOp(int x, int y);

        public delegate int AddDel(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine("*****Async Delegate Invocation*****");

            //Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            //Invoke Add() on a secondary thread.
            AddDel del = new AddDel(AddReturn);
            IAsyncResult iftAR = del.BeginInvoke(10, 10, null, null);

            //Do other work on primary thread...
            Console.WriteLine("Doing more work in Main()!");

            //Obatin the result of the Add() method when ready.
            int answer = del.EndInvoke(iftAR);
            Console.WriteLine(answer);

            Console.ReadLine();
        }

        static void ExtractExecutingThread()
        {
            //Get the thread currently executing this method.
            Thread ct = Thread.CurrentThread;
            Console.WriteLine(ct.ManagedThreadId);
            Console.WriteLine(ct.ApartmentState);
            Console.WriteLine(ct.CurrentCulture);
            Console.WriteLine(ct.CurrentUICulture);
            Console.WriteLine(ct.IsAlive);
            Console.WriteLine(ct.IsBackground);
            Console.WriteLine(ct.IsThreadPoolThread);
            Console.WriteLine(ct.Name);
            Console.WriteLine(ct.Priority);
            Console.WriteLine(ct.ThreadState);             
        }

        static void ExtractCurrentThreadContext()
        {
            //Obtain the context under which the current thread is operating.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine(ctx.ContextID);
            Console.WriteLine(ctx.ContextProperties.FirstOrDefault());
            Console.WriteLine(ctx.ToString());
        }

        static void ExtractAppDomainHostingThread()
        {
            //Obtain the AppDomain hosting the current thread.
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine(ad.ActivationContext);
            Console.WriteLine(ad.ApplicationIdentity);
            Console.WriteLine(ad.ApplicationTrust);
            Console.WriteLine(ad.BaseDirectory);
            Console.WriteLine(ad.DomainManager);
            Console.WriteLine(ad.Evidence);
            Console.WriteLine(ad.FriendlyName);
            Console.WriteLine(ad.IsFullyTrusted);
            Console.WriteLine(ad.IsHomogenous);
            Console.WriteLine();
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        static string AddMethod(int x,int y)
        {
            return string.Format("{0}+{1}={2}", x, y, x + y);
        }

        static void BeginInvokeMethodFinished(IAsyncResult ar)
        {
            Console.WriteLine("The BeginInvoke method has been completed!");
        }

        static int AddReturn(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("AddReturn() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            //Pasuse to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
