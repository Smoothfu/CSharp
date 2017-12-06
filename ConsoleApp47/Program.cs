using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp47
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayDADStats();
            
            Console.ReadLine();
        }

        static void ListAllRunningProcesses()
        {
            //Get all the processes on the local machine order by PID.
            var runningProcs = from proc in Process.GetProcesses()
                               orderby proc.Id
                               select proc;

            if(runningProcs==null)
            {
                return;
            }

            Console.WriteLine("There are {0} procs running now\n\n\n", runningProcs.Count());
            //Print out PID and name of each process.
            foreach(var proc in runningProcs)
            {
                string info = string.Format("->PID:{0} \tName:{1}", proc.Id, proc.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("***********************************************");
        }

        //If there is no process with the PID of 10736,a runtime exception will be thrown.

        static void GetSpecifiedProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(10736);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void EnumThreadsForPid(int pID)
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

            //List out stats for each thread in the specified process.
            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);

            ProcessThreadCollection theThreads = theProc.Threads;
             
            foreach(ProcessThread pt in theThreads)
            {
                string info = string.Format("->Thread ID:{0}  \tStart Time:{1} \tPriority:{2}",
                    pt.Id, pt.StartTime, pt.PriorityLevel);
                Console.WriteLine(info);
            }

            Console.WriteLine("*********************************************************");
        }

        static void EnumModsForPid(int pID)
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

            ProcessModuleCollection theMods = theProc.Modules;
            Console.WriteLine("There are {0} the loaded modules for: {1}\n\n\n\n",theMods.Count, theProc.ProcessName);


            foreach (ProcessModule pm in theMods)
            {
                string info = string.Format("->Mod Name:{0}", pm.ModuleName);
                Console.WriteLine(info);
            }

            Console.WriteLine("*******************************************");
        }

        static void StartAndKillProcess()
        {
            Process ieProc = null;

            //Launch Internet Explorer, and go to tencent with maximized window.
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", "www.qq.com");
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ieProc = Process.Start(startInfo);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("->Hit enter to kill {0}...", ieProc.ProcessName);
            Console.ReadLine();

            //Kill the iexplore.exe process

            try
            {
                ieProc.Kill();
            }

            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayDADStats()
        {
            //Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            //Print out various stats about this domain.
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("Id of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?{0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);

        }
    }
}
