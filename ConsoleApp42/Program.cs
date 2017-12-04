using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts; //For Context type.
using System.Threading;  //For Thread Type.

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("******Fun with Object Context*****\n");

            //Objects will display contextual info upon creation.
            SportsCar sport = new SportsCar();
            Console.WriteLine("\n\n");

            SportCarTS synchroSport = new SportCarTS();
            Console.ReadLine();

        }
    }

    //SportsCar has no special contextual needs and will be loaded into the default context
    //of the AppDomain.

    class SportsCar
    {
        public SportsCar()
        {
            //Get context information and print out context ID.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach(IContextProperty ip in ctx.ContextProperties)
            {
                Console.WriteLine("->Ctx prop:{0}", ip.Name);
            }         
        }
        
    }
    //SportsCarTS demands to be loaded in a synchronization context.
    [Synchronization]

    class SportCarTS:ContextBoundObject
    {
        public SportCarTS()
        {
            //Get context information and print out context ID.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}",
                this.ToString(), ctx.ContextID);

            foreach(IContextProperty ip in ctx.ContextProperties)
            {
                Console.WriteLine("->Ctx Prop:{0}", ip.Name);
            }
        }
    }
}
