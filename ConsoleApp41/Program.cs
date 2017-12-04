using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeNewAppDomainAD();
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

        private static void MakeNewAppDomain()
        {
            //Make a new AppDomain in the current process and list loaded assemblies.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            ListAllAssembliesInAppDomainAD(newAD);
        }

        private static void ListAllAssembliesInAppDomainAD(AppDomain newAD)
        {
            //Now get all loaded assemblies in the default AppDomain.
            var loadedAssemblies = from asm in newAD.GetAssemblies()
                                   orderby asm.GetName().Name
                                   select asm;

            Console.WriteLine("*****Here are the assemblies loaded in {0}*****\n",
                newAD.FriendlyName);

            foreach(var asm in loadedAssemblies)
            {
                Console.WriteLine("->Name:{0}", asm.GetName().Name);
                Console.WriteLine("->Version:{0}\n", asm.GetName().Version);
            }
        }

        private static void MakeNewAppDomainAD()
        {
            //Make a new AppDomain in the current process.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomainAD");
            newAD.DomainUnload += (o, s) =>
            {
                Console.WriteLine("The second AppDomain has been unloaded!");
            };
            try
            {
                //Now load *.dll into this new domain.
                newAD.Load("ConsoleApp35");
            }

            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListAllAssembliesInAppDomainAD(newAD);

            //Now tear down this AppDomain.
            AppDomain.Unload(newAD);
            
        }
    }
}
