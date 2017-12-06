﻿using System;
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
            Console.WriteLine("*****Enter PID of process to investigate*****");
            Console.WriteLine("PID: ");
            string pID = Console.ReadLine();
            int intPID;
            try
            {
                if(int.TryParse(pID, out intPID))
                {
                    EnumThreadsForPid(intPID);
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine("The invalid operation " + ex.Message);
            } 
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
    }
}
