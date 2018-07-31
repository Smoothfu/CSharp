using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp250
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] allProcesses= Process.GetProcesses();
            if(allProcesses!=null && allProcesses.Any())
            {
              var sortedProcesses=   allProcesses.OrderBy(x => x.ProcessName);
                sortedProcesses.All(x =>
                {
                    Console.WriteLine("ProcessName:{0},Id:{1}\n",x.ProcessName, x.Id);
                    return true;
                });
            }
            Console.ReadLine();
        }
    }
}
