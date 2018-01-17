using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ConsoleApp85
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractCurrentThreadContext();
            Console.ReadLine();
        }

        static void ExtractCurrentThreadContext()
        {
            //Obtain the context under which the curret thread is operating.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("ContextID: {0}\nctx:{1}",ctx.ContextID,ctx.ToString());
        }
    }
}
