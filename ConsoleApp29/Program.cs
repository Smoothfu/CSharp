using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    class Program
    {
        //If there is no process with the PID of 7716,a runtime exception will be shown.
        static void Main(string[] args)
        {
            //Prompt user for a PID and print out the set of active threads.
            Console.WriteLine("*****Enter PID of process to investigate*****");
            Console.WriteLine("PID: ");
            string pId = Console.ReadLine();
            int procId = int.Parse(pId);
            DisplayProcessThreads(procId);
           
            Console.ReadLine();
        }

        static void DisplayProcessThreads(int pId)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pId);                 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the loaded modules for: {0}",
                proc.ProcessName);

            ProcessModuleCollection modules = proc.Modules;

            foreach(ProcessModule pm in modules)
            {
                string info = string.Format("->Mod Name: {0}\n,FileName:{1}", pm.ModuleName,pm.FileName);
                Console.WriteLine(info);
            }
        }
    }
}
