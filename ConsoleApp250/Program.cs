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
            Process proc = Process.GetProcessById(5208);
            Console.WriteLine("ProcessName:{0},Id:{1}\n", proc.ProcessName, proc.Id);
           
            Console.ReadLine();
        }
    }
}
