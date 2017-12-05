using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumThreadsForPID(14504);
            Console.ReadLine();
        }

        static void ListProcessAndNames()
        {
            Process.GetProcesses().ToList().ForEach(x =>
            {
                Console.WriteLine("ProcessName:{0},Id:{1}", x.ProcessName, x.Id);
            });  
        }

        static void ListAllRunningProcesses()
        {
            //Get al the processes on the local machine ordered by PID.
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.ProcessName
                               select proc;
            Console.WriteLine("There are totally {0} processes\n\n\n\n", runningProcs.Count());
            //Print out PID and name of each process.
            foreach(var proc in runningProcs)
            {
                string info = string.Format("->PID: {0}\tName:{1}", proc.Id, proc.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("*************************************************88");

        }

        //If there is no process with the PID of 1692,a runtime exception will be thrown.
        static void GetSpecificProcess()
        {
            Process theProcs = null;
            try
            {
                theProcs = Process.GetProcessById(14312);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("ProcessName:{0},ID:{1}", theProcs.ProcessName, theProcs.Id);
        }

        static void EnumThreadsForPID(int PID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(PID);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //List out status for each thread in the specified process.
            Console.WriteLine("Here are the threads used by :{0}", theProc.ProcessName);

            ProcessThreadCollection theThreads = theProc.Threads;

            if(theThreads==null || theThreads.Count<1)
            {
                return;
            }
            Console.WriteLine("There are {0} threads in the {1}\n\n\n\n", theThreads.Count, theProc.ProcessName);


            foreach(ProcessThread pt in theThreads)
            {
                string info = string.Format("->Thread ID:{0} \tStart Time:{1} \tPriority:{2}",
                    pt.Id, pt.StartTime.ToUniversalTime(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
        }
    }
}
