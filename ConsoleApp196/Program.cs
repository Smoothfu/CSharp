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
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(ExtractExecutingThread));
            thread.Start();
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
    }
}
