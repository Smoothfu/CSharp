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
            ListProcessAndNames();
            Console.ReadLine();
        }

        static void ListProcessAndNames()
        {
            var procs = Process.GetProcesses();
            if(procs!=null && procs.Count()>0)
            {

                Console.WriteLine("There are {0} processes!\n\n\n", procs.Count());

                procs.ToList().ForEach(x =>
                {
                    Console.WriteLine("ProcessName:{0},Id:{1}",x.ProcessName, x.Id);
                });
            } 
        }
    }
}
