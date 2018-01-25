using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp91
{
    class Program
    {
        static void Main(string[] args)
        {
            //The main thread uses AutoResetEvent to signal the registered wait handle,which executes the callback method.
            AutoResetEvent ev = new AutoResetEvent(false);

            TaskInfo ti = new TaskInfo();
            ti.otherInfo = "First task";

            //The TaskInfo for the task includes the registered wait handle returned by RegisterWaitForSingleObject.This allows
            //the wait to be terminated when the object has been singaled once.

            ti.handle = ThreadPool.RegisterWaitForSingleObject(ev,
                new WaitOrTimerCallback(WaitProc), ti, 1000, false);

            //The main thread waits three seconds,to demonstrate the time-outs on the queued thread.and then signals.
            Thread.Sleep(3100);
            Console.WriteLine("Main thread signals.\n");
            ev.Set();

            //The main thread sleeps,which should give the callback method time to execute. If you comment out this line,
            //the program usually ends before the ThreadPool thread can execute.
            Thread.Sleep(1000);

            //If you start a thread yourself,you can wait for it to end by calling Thread.Join.This option is not 
            //available with thread pool threads.

            Console.ReadLine();
             

            Console.ReadLine();
        }

        public static void WaitProc(object state,bool timedout)
        {
            //The state object must be cast to the correct type,because the signature of the WaitOrTimerCallback
            //delegate specifies type object.
            TaskInfo ti = (TaskInfo)state;
            string cause = "TIMED OUT";
            if(!timedout)
            {
                cause = "SIGNALED";
                //If the callback method executes because the WaitHandle is signaled,stop future execution
                //of the callback method by unregistering the WaitHandle.
                if(ti.handle!=null)
                {
                    ti.handle.Unregister(null);
                }
            }
        }

        //This method procedure performs the task.
        static void ThreadProc(object stateInfo)
        {
            //No state object was passed to QueueUserWorkItem,so stateinfo is null.
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("ThreadProc ManagerThreadId :{0} \n", thread.ManagedThreadId);
            Console.WriteLine("Hello from the thread pool.\n");
        }
    }

    //TaskInfo contains data that will be passed to the callback method.
    public class TaskInfo
    {
        public RegisteredWaitHandle handle = null;
        public string otherInfo = "default";
    }

    
     
}
