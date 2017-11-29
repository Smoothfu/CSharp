using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get all the processes on the local machine,ordered by PID.
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.Id
                               select proc;

            //Print out PID and name of each process.

            foreach(var p in runningProcs)
            {
                string info = string.Format("PID:{0} \t Name: {1}", p.Id, p.ProcessName);
                Console.WriteLine(info);
            }

             Console.ReadLine();
        }
    }
}
