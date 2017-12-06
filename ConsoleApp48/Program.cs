using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleApp48
{
    class Program
    {
        static void Main(string[] args)
        {
            ListAllAssembliesInAppDomainOrder();
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
    }
}
