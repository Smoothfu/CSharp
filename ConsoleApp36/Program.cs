using System;
using System.Diagnostics;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The currently running process infomation");
            PrintOutProcs();
            Console.ReadLine();
        }

        static void PrintOutProcs()
        {
            Process[] procArr = Process.GetProcesses(".");
            if(procArr == null)
            {
                return;
            }

            foreach(Process proc in procArr)
            {
                string info = string.Format("The proc id:{0} \tMachineName:{1}", proc.Id, proc.MachineName);
                Console.WriteLine(info);
            }
        }
    }
}
