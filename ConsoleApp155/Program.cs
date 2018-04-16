﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp155
{
    class Program
    {
        static int x = 100000, y = 200000000;
        delegate void AddDel(ref int x, ref int y);
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                ExtractAppDomainHostingThread();
            });
            
            Console.ReadLine();
        }

        static void AddMethod(ref int x, ref  int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            x = x + 1000;
            y = y + 1000;
            Console.WriteLine("Now x is {0},y is {1}", x, y);
        }

        static void ExtractExecutingThread()
        {
            //Get the thread currently executing this method.
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine("ManagedThreadId:{0}\n",currentThread.ManagedThreadId);
            Console.WriteLine("Name:{0}\n",currentThread.Name);
            Console.WriteLine("Priority:{0}\n", currentThread.Priority);
            Console.WriteLine("ThreadState:{0}\n", currentThread.ThreadState);
            Console.WriteLine("CurrentCulture:{0}\n",currentThread.CurrentCulture);
            Console.WriteLine("CurrentUICulture:{0}\n",currentThread.CurrentUICulture);
            Console.WriteLine("IsAlive:{0}\n",currentThread.IsAlive);
            Console.WriteLine("IsBackground:{0}\n", currentThread.IsBackground);
            Console.WriteLine("IsThreadPoolThread:{0}\n", currentThread.IsThreadPoolThread); 
        }

        static void ExtractAppDomainHostingThread()
        {
            //Obtain the AppDomain hosting the current thread.
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine("BaseDirectory:{0}\n", ad.BaseDirectory);
            Console.WriteLine("DomainManager:{0}\n", ad.DomainManager);
            Console.WriteLine("DynamicDirectory:{0}\n", ad.DynamicDirectory);
            Console.WriteLine("Evidence:{0}\n", ad.Evidence);
            Console.WriteLine("FriendlyName:{0}\n", ad.FriendlyName);
            Console.WriteLine("Id:{0}\n", ad.Id);
            Console.WriteLine("IsFullyTrusted:{0}\n", ad.IsFullyTrusted);
            Console.WriteLine("IsHomogenous:{0}\n", ad.IsHomogenous);
            Console.WriteLine("RelativeSearchPath:{0}\n", ad.RelativeSearchPath);
            Console.WriteLine("SetupInformation:{0}\n",ad.SetupInformation);
        }
        
    }
}
