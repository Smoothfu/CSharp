using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp99
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtratctAppDomainHostingThread();
            Console.ReadLine();
        }

        static void ExtractExecutingThread()
        {
            //Get the thread currently.
            //executing this method.
            Thread currThread = Thread.CurrentThread;
            Console.WriteLine("ManagedThreadId: {0}\n", currThread.ManagedThreadId);
            Console.WriteLine("Name: {0}\n",currThread.Name);
            Console.WriteLine("IsThreadPoolThread:{0}\n", currThread.IsThreadPoolThread);
            Console.WriteLine("IsBackground:{0}\n", currThread.IsBackground);
            Console.WriteLine("CurrentCulture:{0}\n", currThread.CurrentCulture);
            Console.WriteLine("CurrentUICulture: {0}\n",currThread.CurrentUICulture);  
        }

        static void ExtratctAppDomainHostingThread()
        {
            //Obtain the Application hosting the current thread.
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine("ApplicationIdentity:{0}\n", ad.ApplicationIdentity);
            Console.WriteLine("ApplicationTrust:{0}\n", ad.ApplicationTrust);
            Console.WriteLine("BaseDirectory:{0}\n", ad.BaseDirectory);
            Console.WriteLine("DomainManager:{0}\n", ad.DomainManager);
            Console.WriteLine("DynamicDirectory:{0}\n", ad.DynamicDirectory);
            Console.WriteLine("FriendlyName:{0}\n", ad.FriendlyName);
            Console.WriteLine("Id:{0}\n", ad.Id);
            Console.WriteLine("IsHomogenous:{0}\n", ad.IsHomogenous);
            //Console.WriteLine("MonitoringSurvivedMemorySize:{0}\n", ad.MonitoringSurvivedMemorySize);
            //Console.WriteLine("MonitoringTotalAllocatedMemorySize:{0}\n", ad.MonitoringTotalAllocatedMemorySize);
            //Console.WriteLine("MonitoringTotalProcessorTime:{0}\n", ad.MonitoringTotalProcessorTime);
            Console.WriteLine("PermissionSet:{0}\n", ad.PermissionSet);
            Console.WriteLine("RelativeSearchPath:{0}\n", ad.RelativeSearchPath);
        }


    }
}
