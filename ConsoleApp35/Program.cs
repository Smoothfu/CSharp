using System;
using System.Diagnostics;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prompt user for a PID and print out the set of active threads.
            Console.WriteLine("*****Enter PID of process to investigate*****");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);
            EnumThreadsForPid(theProcID);
            Console.ReadLine();
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
            ProcessThreadCollection threadCollection = theProc.Threads;

            foreach(ProcessThread pt in threadCollection)
            {
                string info = string.Format("->Thread ID:{0} \t Start Time:{1} \t Priority:{2}",
                    pt.Id, pt.StartTime.ToString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("*************************************************");
        }
    }
}
