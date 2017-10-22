using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp82
{
    delegate void AsyncFoo(int i);
    class Program
    {
        /// <summary>
        /// 输出当前线程的信息
        /// </summary>
        /// <param name="args">方法名称</param>
        static void PrintCurrentThreadInfo(string name)
        {
            Console.WriteLine("ThreadId of " + name +" is " + Thread.CurrentThread.ManagedThreadId 
                + " , current thread is " + (Thread.CurrentThread.IsThreadPoolThread ? " " : " not ")
                + " thread pool thread.");
        }

        /// <summary>
        /// 测试方法，Sleep一定时间
        /// </summary>
        /// <param name="args">Sleep的时间</param>
        static void Foo(int i)
        {
            PrintCurrentThreadInfo("Foo()");
            Thread.Sleep(i);
        }

        /// <summary>
        /// 投递一个异步调用
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
            for(int i=0;i<10;i++)
            {
                PostAsync();
            }

            Console.ReadLine();
        }
    }
}
