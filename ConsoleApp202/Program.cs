using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.Runtime.Remoting.Contexts;


namespace ConsoleApp202
{
    public delegate void AddDel(int x, int y);
    public delegate int AddIntDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synch Delegate Review*****");
            
            //Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Invoke AddIntMethod() in a synchronous manner.
            AddIntDel addIntDel = new AddIntDel(AddIntMethod);

            IAsyncResult asyncResult = addIntDel.BeginInvoke(3241, 321423, new AsyncCallback(AddMethodCompleted), null);

            //The message will keep printing until the Add() method is finished.
            while(!asyncResult.IsCompleted)
            {
                Console.WriteLine("Now is {0}", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            }
            //Do other work on primary thread...
            Console.WriteLine("Doing more work in Main()!\n");

            //Obtain the result of the Add() method when ready.
            int answer = addIntDel.EndInvoke(asyncResult);            
            
            Console.WriteLine("The add result is " + answer);
            Console.ReadLine();
        } 


        static void AddMethodCompleted(IAsyncResult asyncResult)
        {
            Console.WriteLine("The AddMethodCompleted thread id is " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("The AddIntMethod has been completed!\n ");
        }
        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
        
        static int AddIntMethod(int x,int y)
        {
            //Print out the ID of the executing thread 
            Console.WriteLine("Add() invoked on thread {0}.\n", Thread.CurrentThread.ManagedThreadId);

            //Pause to simulate a lengthy operation
            Thread.Sleep(5000);
            return x + y;
        }


        
       static void ExtractAppDomainHostingThread()
        {
            //Obtain the AppDomain hosting the current thread.
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine(ad.ApplicationIdentity);
            Console.WriteLine(ad.ApplicationTrust);
            Console.WriteLine(ad.BaseDirectory);
            Console.WriteLine(ad.DomainManager);
            Console.WriteLine(ad.Evidence);
            Console.WriteLine(ad.FriendlyName);
            Console.WriteLine(ad.Id);
            Console.WriteLine(ad.IsFullyTrusted);
            Console.WriteLine(ad.IsHomogenous);
            Console.WriteLine(ad.PermissionSet);
            Console.WriteLine(ad.RelativeSearchPath);
            Console.WriteLine(ad.SetupInformation);
            Console.WriteLine(ad.ShadowCopyFiles);
            Console.WriteLine(ad.ToString());
            Console.ReadLine();
        }

       static void ExtractCurrentThreadContext()
        {
            //Obtain the context under which the current thread is operating.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0,-30}",ctx.ContextID);
            Console.WriteLine(ctx.ToString());
            Console.ReadLine();
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

        public void GetPersonInfo()
        {
            Console.WriteLine("PId:{0},PName:{1}\n", PId, PName);
        }
        public override string ToString()
        {
            return string.Format("PId:{0},PName:{1}\n", PId, PName);
        }
    }
}
