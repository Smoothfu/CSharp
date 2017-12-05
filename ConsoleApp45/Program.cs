using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleApp45
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDAD();
            MakeNewAppDomain();
            Console.ReadLine();
        }

        private static void InitDAD()
        {
            //This logic will print out the name of any assembly loaded into the application domain,
            //after it has been created.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            //defaultAD.AssemblyLoad += DefaultAD_AssemblyLoad;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };

        }

        private static void DefaultAD_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("{0} has been loaded!", args.LoadedAssembly.GetName().Name);
        }

        private static void MakeNewAppDomain()
        {
            //Make a new AppDomain in the current process and list loaded assemblies
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            ListAllAssembliesInAppDomain(newAD);
        }

        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            //Now get all loaded assemblies in the default AppDomain.
            var loadedAssemblies = from asm in
                                       ad.GetAssemblies()
                                   orderby asm.GetName().Name
                                   select asm;
            Console.WriteLine("********Here are the assemblies loaded in{0}*********\n",ad.FriendlyName);

            foreach(var asm in loadedAssemblies)
            {
                Console.WriteLine("->Name:{0}", asm.GetName().Name);
                Console.WriteLine("->Version:{0}\n", asm.GetName().Version);
            }

        }
    }
}
