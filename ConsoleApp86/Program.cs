using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp86
{
    delegate void AsyncFoo(int i);
    class Program
    {
        /// <summary>
        /// print the current thead information
        /// </summary>
        /// <param name="args"></param>
        
        static void PrintCurrentThreadInfo(string name)
        {
            Console.WriteLine("ThreadId of " + name + " is " + Thread.CurrentThread.ManagedThreadId + ", current thread is " +
                (Thread.CurrentThread.IsThreadPoolThread ? "" : "not ") + " thread pool thread.");

        }

        /// <summary>
        /// Test method Sleep for some seconds
        /// </summary>
        /// <param name="args"></param>
        
       static void Foo(int i)
        {
            PrintCurrentThreadInfo("Foo()");
            Thread.Sleep(i);
        }

        /// <summary>
        /// invoke a asynchronous call
        /// </summary>
        /// <param name="args"></param>
        static void PostAsync()
        {
            AsyncFoo caller = new AsyncFoo(Foo);
            caller.BeginInvoke(1000, new AsyncCallback(FooCallBack), caller);
        }

        static void FooCallBack(IAsyncResult ar)
        {
            PrintCurrentThreadInfo("FooCallBack()");
            AsyncFoo caller = (AsyncFoo)ar.AsyncState;
            caller.EndInvoke(ar);
        }
        static void Main(string[] args)
        {
            PrintCurrentThreadInfo("Main()");
            for(int i=0;i<5;i++)
            {
                PostAsync();
            }
            Console.ReadLine();
        }
    }
}
