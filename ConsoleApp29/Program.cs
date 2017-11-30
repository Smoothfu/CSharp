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
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(7716);
                Console.WriteLine(proc.ProcessName);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
