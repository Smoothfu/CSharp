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
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synch Delegate Review*****");

            //Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Invoke Add() in a synchronous manner.
            BinaryOp op = new BinaryOp(AddMethod);

            //Could also write op.Invoke(100443,345234);
            string answer = op.Invoke(24524655, 3452345);

            //These lines will not execute until the AddMethod() has completed.
            Console.WriteLine("Doing more work in Main()!\n");
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
    }
}
