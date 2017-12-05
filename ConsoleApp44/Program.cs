using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayDADStats();
            Console.ReadLine();
        }

        private static void DisplayDADStats()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            //Print out various stats aout this domain.
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process:{0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?:{0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);


        }
    }
}
