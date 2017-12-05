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
            GetSpecificProcess();
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
    }
}
