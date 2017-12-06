using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace ConsoleApp48
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********Fun with Custom AppDomains*******\n");

            //Show all loaded assemblies in default AppDomain.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.ProcessExit += (o, s) =>
            {
                Console.WriteLine("Default AD unloaded!");
            };
            ListAllAssembliesInAppDomain(defaultAD);
            Console.ReadLine();
        }
        
        static void ListAllAssembliesInAppDomain()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            //Now get all loaded assemblies in the default AppDomain.
            Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            Console.WriteLine("*****************Here are the assemblies loaded in{0}**************\n",defaultAD.FriendlyName);

            foreach(Assembly asm in loadedAssemblies)
            {
                Console.WriteLine("->Name: {0}\t    Version:{1}\t", asm.GetName().Name, asm.GetName().Version);
            }

        }

        static void ListAllAssembliesInAppDomainOrder()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            //Now get all loaded assemblies in the default AppDomain.
            var loadedAssemblies = from asm in defaultAD.GetAssemblies()
                                   orderby asm.GetName().Name
                                   select asm;

            Console.WriteLine("*******Here are the assemblies loaded in {0}**************\n", defaultAD.FriendlyName);

            Console.WriteLine("{0,-30}{1,-100}{2,10}", "Name", "FullName", "Version");
            foreach(var asm in loadedAssemblies)
            {
                string info = string.Format("{0,-30}{1,-100}{2,10}", asm.GetName().Name, asm.FullName,asm.GetName().Version);
                Console.WriteLine(info);
            }
        }

        private static void InitDAD()
        {
            //This logic will print out the name of ant assembly.
            //loaded into the application domain,after it has been created.

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

            newAD.DomainUnload += (o, s) =>
            {
                Console.WriteLine("The second AppDomain has been unloaded!");
            };
            try
            {
                //Now load ConsoleApp47.exe into this new domain.
                newAD.Load("ConsoleApp47");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListAllAssembliesInAppDomain(newAD);
        }

        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            //Now get all loaded assemblies in the default AppDomain.
            var loadedAssemblies=from asm in ad.GetAssemblies()
                                 orderby asm.GetName().Name
                                 select asm;

            Console.WriteLine("*****Here are the assemblies loaded in {0}*****\n", ad.FriendlyName);

            foreach(var a in loadedAssemblies)
            {
                Console.WriteLine("->Name:{0,-30}Version:{1,-10}", a.GetName().Name, a.GetName().Version);
            }
        }
    }
}
