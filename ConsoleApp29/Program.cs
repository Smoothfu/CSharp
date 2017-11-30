using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    class Program
    {
        //If there is no process with the PID of 7716,a runtime exception will be shown.
        static void Main(string[] args)
        {
            //Prompt user for a PID and print out the set of active threads.
            Console.WriteLine("*****Enter PID of process to investigate*****");
            Console.WriteLine("PID: ");
            string pId = Console.ReadLine();
            int procId = int.Parse(pId);
            DisplayProcessThreads(procId);
           
            Console.ReadLine();
        }

        static void DisplayProcessThreads(int pId)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pId);
                Console.WriteLine(proc.ProcessName);

                ProcessThreadCollection threads = proc.Threads;

                if (threads != null && threads.Count > 0)
                {
                    foreach (ProcessThread pt in threads)
                    {
                        string info = string.Format("->Thread ID:{0} \t Start Time: {1} \t Priority:{2}", pt.Id,
                            pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                        Console.WriteLine(info);
                    }

                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
