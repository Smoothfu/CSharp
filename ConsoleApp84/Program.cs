using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp84
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractAppDomainHostingThread();
            Console.ReadLine();
        }

        static void ExtractExecutingThread()
        {
            //Get the thread currently executing this method.
            Thread currThread = Thread.CurrentThread;
            Console.WriteLine("ManagedThreadId: {0}\n",currThread.ManagedThreadId);
            Console.WriteLine("IsAlive:{0}\nIsBackground:{1}\nIsThreadPoolThread:{2}\nCurrentCulture:{3}\n"+
                "CurrentUICulture:{4}\nName:{5}\nPriority:{6}\nThreadState:{7}\n",currThread.IsAlive,
                currThread.IsBackground, currThread.IsThreadPoolThread, 
                currThread.CurrentCulture.ToString(), currThread.CurrentUICulture.ToString(),
                currThread.Name,currThread.Priority, currThread.ThreadState);
        }

        static void ExtractAppDomainHostingThread()
        {
            //obtain the AppDomain hosting the current thread.
            AppDomain ad = Thread.GetDomain();
            string str = string.Format("ApplicationIdentity:{0}\nBaseDirectory:{1}\nDynamicDirectory:{2}\n" +
            "FriendlyName:{3}\nId:{4}\nIsDefaultAppDomain:{5}\nIsFinalizingForUnload:{6}\nIsFullyTrusted:{7}\n" +
            "IsHomogenous:{8}\nPermissionSet:{9}\nRelativeSearchPath:{10}",
            ad.ApplicationIdentity, ad.BaseDirectory, ad.DynamicDirectory,
            ad.FriendlyName, ad.Id, ad.IsDefaultAppDomain(), ad.IsFinalizingForUnload(),
            ad.IsFullyTrusted, ad.IsHomogenous,
            ad.PermissionSet, ad.RelativeSearchPath);
            Console.WriteLine(str);
        }
    }
}
