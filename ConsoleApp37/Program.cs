using System;
using System.Diagnostics;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumMethodsForPid(9760);
            Console.ReadLine();
        }

        static void EnumMethodsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the loaded modules for: {0}", theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;
            foreach(ProcessModule pm in theMods)
            {
                string info = string.Format("->Mod Name:{0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("***********************************************");
        }
    }
}
