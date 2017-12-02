using System;
using System.Diagnostics;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSpecificProcess(9880);
            Console.ReadLine();
        }

        //If there is no process with the PID of 9880,a runtime exception will be thrown
        static void GetSpecificProcess(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
                Console.WriteLine("The specified process's PID is {0} and process name is {1}", theProc.Id, theProc.ProcessName);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //List out status for each thread in the specified process.
            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);

            ProcessThreadCollection threadCollection = theProc.Threads;

            if(threadCollection==null || threadCollection.Count==0)
            {
                return;
            }

            Console.WriteLine("There are {0} {1} in the process\n", threadCollection.Count,
                threadCollection.Count > 1 ? "threads" : "thread");
            foreach(ProcessThread pt in threadCollection)
            {
                string info = string.Format("->Thread ID:{0} \t Thread Address:{1} \t Start Time: {2} \t Priority:{3} \t",
                    pt.Id,pt.StartAddress, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
        }
    }
}
