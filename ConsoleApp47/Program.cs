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
            Console.WriteLine("************Fun with Processes************\n");
            ListAllRunningProcesses();
            Console.ReadLine();
        }

        static void ListAllRunningProcesses()
        {
            //Get all the processes on the local machine order by PID.
            var runningProcs = from proc in Process.GetProcesses()
                               orderby proc.ProcessName
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
    }
}
