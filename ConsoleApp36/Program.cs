using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp36
{
    class Program
    {
        static int num = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("The threads of the  currently running process infomation");
            PrintOutProcs();
            Console.WriteLine("Currently there are totally {0} threads in process", num);
            Console.ReadLine();
        }

        static void PrintOutProcs()
        {
            var procArr = Process.GetProcesses(".");
            if(procArr == null)
            {
                return;
            }

            procArr = (from proc in procArr orderby proc.ProcessName select proc).ToArray();
            foreach(Process proc in procArr.OrderBy(x=>x.Threads.Count))
            {                
                ProcessThreadCollection ptc = proc.Threads;
                Console.WriteLine("There are {0} {1} in the {2}", ptc.Count, ptc.Count > 1 ? "threads" : "thread", proc.ProcessName);

                foreach (ProcessThread pt in ptc)
                {
                    if (pt.Id == 0)
                    {
                        continue;
                    }
                    string info = string.Format("->Thread ID:{0}",
                        pt.Id);
                    Console.WriteLine(info);                   
                    num++;
                }
                Console.WriteLine("\n");
            }
        }
    }
}
