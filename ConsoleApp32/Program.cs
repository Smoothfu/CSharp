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
            var runningAllProcs = from proc in Process.GetProcesses()
                               orderby proc.ProcessName select proc;
            Console.WriteLine("Process.GetProcess()'s process count is {0}\n", runningAllProcs.Count());
            var runningProcs = from proc in Process.GetProcesses(".") orderby proc.ProcessName select proc;
            Console.WriteLine("Process.GetProcess(\".\")'s process count is {0}\n", runningProcs.Count());
            var newProcs = runningAllProcs.Where(x => !runningProcs.Any(y => y.Id == x.Id));

           if(newProcs==null||!runningProcs.Any())
            {
                return;
            }

            Console.WriteLine("The difference between GetProcess(\".\") and GetProcess()：\n");

            foreach(var proc in runningProcs)
            {
                Console.WriteLine(string.Format("The process by Process.GetProcess(\".\") and its Id is:{0} and Process Name is :{1}", proc.Id, proc.ProcessName));
            }


             
           

            //Print out PID and name of each process

            //if (runningProcs==null ||!runningProcs.Any())
            //{
            //    return;
            //}

            //Console.WriteLine("There are {0} process running now\n", runningProcs.Count());
            //foreach(var proc in runningProcs)
            //{
            //    string info = string.Format("->PID: {0}\tName :{1}", proc.Id, proc.ProcessName);
            //    Console.WriteLine(info);
            //}
            Console.ReadLine();
        }
    }
}
