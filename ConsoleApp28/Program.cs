using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] proList = Process.GetProcesses();
            foreach(var pl in proList)
            { 
                Console.WriteLine(pl.Handle);
                Console.WriteLine(pl.Id);
                Console.WriteLine(pl.MachineName); 
                Console.WriteLine(pl.SessionId); 
            }

            Console.ReadLine();
        }
    }
}
