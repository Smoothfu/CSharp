using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            ListAllAssembliesInAppDomain();
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
    }
}
