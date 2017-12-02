using System;
using System.Diagnostics;
using System.Linq;
namespace ConsoleApp32
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get all the processes on the local machine,ordered by PID
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.ProcessName select proc;

            //Print out PID and name of each process

            if(runningProcs==null ||!runningProcs.Any())
            {
                return;
            }

            Console.WriteLine("There are {0} process running now\n", runningProcs.Count());
            foreach(var proc in runningProcs)
            {
                string info = string.Format("->PID: {0}\tName :{1}", proc.Id, proc.ProcessName);
                Console.WriteLine(info);
            }
            Console.ReadLine();
        }
    }
}
