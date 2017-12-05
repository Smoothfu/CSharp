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
            var currentProc = Process.GetCurrentProcess();

            Console.WriteLine("{0},{1}",currentProc.MainModule, currentProc.ProcessName);
        }
    }
}
