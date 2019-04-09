using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleApp335
{
    class Program
    {
        static string logFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
        static string popUpMsg = string.Empty;
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    DateTime startDt = DateTime.Now;
                    DateTime endDt = startDt.AddSeconds(10);
                    while (DateTime.Now < endDt)
                    {
                        string msg = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        stringBuilder.Append(msg);
                    }
                    LogMessage(stringBuilder.ToString());
                }

                popUpMsg = $"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is {Process.GetCurrentProcess().PrivateMemorySize64}";
                MessageBox.Show(popUpMsg);
            }
            catch(Exception ex)
            {
                popUpMsg = $"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is {Process.GetCurrentProcess().PrivateMemorySize64}";
                MessageBox.Show(popUpMsg);
            }         
        }
        static void LogMessage(string logMsg)
        {
            try
            {
                using (StreamWriter logWriter = new StreamWriter(logFullName, true))
                {
                    logWriter.WriteLine(logMsg);
                }
            }
            catch(Exception ex)
            {
                popUpMsg = $"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is {Process.GetCurrentProcess().PrivateMemorySize64}";
                MessageBox.Show(popUpMsg);
            }            
        }
    }
}
