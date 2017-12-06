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
            ListAllAssembliesInAppDomain();
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
    }
}
