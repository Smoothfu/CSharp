using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ConsoleApp417
{
    class Program
    {
        static void Main(string[] args)
        {
            ExclusiveMutexDemo();
            Console.ReadLine();
        }

        static void Log4netDemo()
        {
            string msg = $"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},Guid is {Guid.NewGuid()}";
            Log4netHelper.LogInfo(msg);
            Log4netHelper.LogDebug(msg);
            Log4netHelper.LogError(msg);
            Log4netHelper.LogWarn(msg);
        }

        static void ExclusiveMutexDemo()
        {
            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            bool isCreatedNew;
            var mutext = new Mutex(true, assemblyName, out isCreatedNew);
            if(!isCreatedNew)
            {
                Console.WriteLine("The app is running");
                System.Environment.Exit(0);
            }
            Console.WriteLine("Started!");
        }        
    }
}
