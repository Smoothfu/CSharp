using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            StartAndKillProcess();
            Console.ReadLine();
        }

        static void StartAndKillProcess()
        {
            Process ieProc = null;
            //Launch Internet Explorer,and go to tencent!
            try
            {
                ieProc=Process.Start("IExplore.exe", "www.qq.com");
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("->Hit enter to kill {0}...", ieProc.ProcessName);
            Console.ReadLine();

            //Kill the iexplore.exe process.
            try
            {
                ieProc.Kill();
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
