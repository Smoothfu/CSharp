﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp155
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine("*****AsyncCallbackDelegate Example*****\n");
            Console.WriteLine("Main() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            BinaryOp bo = new BinaryOp(Add);
            IAsyncResult asyncResult = bo.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers.\n");

            //Assume other work is performed here...
            while(!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working....");
            }
             
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

        static void ExtractCurrentThreadContext()
        {
            //Obtain the context under which the current is operating.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("ContextID:{0}\n",ctx.ContextID);
            Console.WriteLine("ContextProperties:{0}\n",ctx.ContextProperties);
        }

        static int Add(int x,int y)
        {
            //Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult asyncResult)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete!\n");

            //Now get result.
            AsyncResult ar = (AsyncResult)asyncResult;
            BinaryOp bo = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10+10 is {0}\n", bo.EndInvoke(asyncResult));

            //Retrieve the informational object and cast it to string.
            string msg = (string)asyncResult.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }        
    }
}
