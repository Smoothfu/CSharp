using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp354
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the worker thread object.this does not start the thread.
            Worker workerObj = new Worker();
            Thread workerThread = new Thread(workerObj.DoWork);

            //Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread:starting worker thread...");

            ////Loop until the worker thread activates.
            while (!workerThread.IsAlive)
            {
                ;
            }

            //Put the main thread to sleep for 500 milliseconds to allow the worker 
            //thread to do some work.
            Thread.Sleep(500);

            //Request that the worker thread stop itself.
            workerObj.RequestStop();

            //Use the Thread.Join method to block the current thread until the objects'
            // thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated!");
            Console.ReadLine();
        }
    }

    public class Worker
    {
        //Keyword volatile is used as a hint to the compiler that this data member 
        //is accessed by multiple threads.
        private volatile bool _ShouldStop;
        //This method is called when the thread is started
        public void DoWork()
        {
            bool isWork = false;
            while(!_ShouldStop)
            {
                //simulate some work.
                isWork = !isWork;
            }
            Console.WriteLine("Worker thread:terminating gracefully!");
        }

        public void RequestStop()
        {
            _ShouldStop = true;
        }
    }
}
