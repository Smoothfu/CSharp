using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp11
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Create the worker thread object.
            //This does not start the thread.
            Worker workerObj = new Worker();
            Thread workThread = new Thread(workerObj.DoWork);

            //Start the worker thread.
            workThread.Start();
            Console.WriteLine("Main thread:starting worker thread...");

            //Loop until the worker thread activates.
            while (!workThread.IsAlive) ;

            //Put the main thread to sleep for 1 milliseconds to allow the worker thread to do some worl
            Thread.Sleep(1);

            //Request that the worker thread stop itsself.
            workerObj.RequestStop();

            //use the Thread.Join method to block the current thread until the objects thread terminates.
            workThread.Join();
            Console.WriteLine("Main thread:worker thread has terminated!");
            Console.ReadLine();
        }

        static void RunBackgroundServiceThreadPriority(object service)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            ((IService)service).Execute();
        }

        static void RunBackgroundService(object service)
        {
            ((IService)service).Execute();
        }

        static void GetCurrentTime()
        {
            Console.WriteLine("Now is {0}\n", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }


        static void DescPerson(object obj)
        {
            var personObj = obj as Person;
            if(personObj!=null)
            {
                Console.WriteLine(personObj.ToString());
            }
        }
         
        static void ExecuteLongRunningOperation(object milliseconds)
        {
            Thread.Sleep((int)milliseconds);
            Console.WriteLine("Operation completed successfully!\n");
        }

    }

    public class Person
    {
        public int PId { get; set; }
        public string PName { get; set; }

        public Person(int pId,string pName)
        {
            PId = pId;
            PName = pName;
        }

        public override string ToString()
        {
            return string.Format("Id:{0},Name:{1}\n", PId, PName);
        } 
    }

    public interface IService
    {
        string Name { get; set; }
        void Execute();
    }

    public class EmailService : IService
    {
        public string Name { get ; set ; }

        public void Execute()
        {
            Console.WriteLine("The Name is {0} \n.", Name);
        }

        public EmailService(string name)
        {
            this.Name = name;
        }
    }

    public class Worker 
    {
        //Keyword volatile is used as a hint to the compiler that thsi data member is accessed 
        //by multiple threads.
        private volatile bool _shouldStop;
        //This method is called when the thread is started.
        public void DoWork()
        {
            while(!_shouldStop)
            {
                Console.WriteLine("Worker thread:working...");
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
