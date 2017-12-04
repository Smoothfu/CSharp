using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDAD();
            ListAllAssembliesInAppDomainAD();
            MessageBox.Show("Finished");
            Console.ReadLine();
        }

        private static void DisplayDADStats()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            //Print out various stats about this domain.
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);

            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain? :{0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
        }

        static void ListAllAssembliesInAppDomain()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            //Now get all loaded assemblies in the default AppDomain.
            Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            Console.WriteLine("*****Here are the assemblies loaded in {0} *****\n",
                defaultAD.FriendlyName);
            foreach(Assembly asm in loadedAssemblies)
            {
                Console.WriteLine("->Name:{0}", asm.GetName().Name);
                Console.WriteLine("->Version:{0}\n", asm.GetName().Version);
            }
        }

        static void ListAllAssembliesInAppDomainAD()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            //Now get all loaded assemblies in the default AppDomain.
            var loadedAssemblies = from asm in defaultAD.GetAssemblies()
                                   orderby asm.GetName().Name
                                   select asm;

            Console.WriteLine("*****Here are the assemblies loaded in {0}*****\n",defaultAD.FriendlyName);

            foreach(var asm in loadedAssemblies)
            {
                Console.WriteLine("->Name:{0}", asm.GetName().Name);
                Console.WriteLine("->Version:{0}\n", asm.GetName().Version);
            }

        }

        private static void InitDAD()
        {
            //This logic will print out the name of any assembly
            //loaded into the applocation domain,after it has been created.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }
    }
}
