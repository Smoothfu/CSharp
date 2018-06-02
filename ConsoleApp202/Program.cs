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
    class Program
    {
        static void Main(string[] args)
        {
            ExtractCurrentThreadContext();
            Console.ReadLine();
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
