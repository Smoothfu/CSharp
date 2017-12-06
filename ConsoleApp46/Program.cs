using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with custom AppDomains*****\n");

            //Show all loaded assemblies in default AppDomain.

            AppDomain defaultAD = AppDomain.CurrentDomain;
            ListAllAssembliesInAppDomain(defaultAD);
            //Make a new AppDomain.
            MakeNewAppDomain();
            Console.ReadLine();
        }

        static void ListAllAssembliesInAppDomain()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            //Now get all loaded assemblies in the default AppDomain.
            var loadedAssemblies = from asm in defaultAD.GetAssemblies()
                                   orderby asm.GetName().Name
                                   select asm;

            Console.WriteLine("***********Here are the assemblies loaded in {0} **************\n", defaultAD.FriendlyName);
            foreach(var asm in loadedAssemblies)
            {
                Console.WriteLine("->Name:{0}", asm.GetName().Name);
                Console.WriteLine("->Version:{0}\n", asm.GetName().Version);
            }
        }

        private static void InitADD()
        {
            //This logic will print out the name of any assembly loaded into the application domain,after it has been created.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };



        }

        private static void MakeNewAppDomain()
        {
            //Make a new AppDomain in the current process.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            try
            {
                //Now load ConsoleApp43.exe into this new domain.
                newAD.Load("ConsoleApp43");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Lista all assemblies
            ListAllAssembliesInAppDomain(newAD);
        }

        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            //Now get all loaded asemblies in the default AppDomain.
            var loadedAssemblies = from asm in ad.GetAssemblies()
                                   orderby asm.GetName().Name
                                   select asm;

            Console.WriteLine("********Here are the assemblies loaded in {0}********\n");
            foreach(var asm in loadedAssemblies)
            {
                Console.WriteLine("->Name: {0}\n", asm.GetName().Name);
                Console.WriteLine("->Version: {0}\n", asm.GetName().Version);
            }
        }
    }
}
