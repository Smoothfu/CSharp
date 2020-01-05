using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using log4net;

namespace ConsoleApp409
{
    class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            for (int i = 0; i < 100000; i++)
            {
                Log4netDemo();
            }
        }

        static void Log4netDemo()
        {
            StringBuilder logBuilder = new StringBuilder();
            logBuilder.AppendLine($"Info.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logBuilder.AppendLine($"Info.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logBuilder.AppendLine($"Debug.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logBuilder.AppendLine($"Error.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logBuilder.AppendLine($"Fatal.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logBuilder.AppendLine($"Warn.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Info($"Info.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Debug($"Debug.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Error($"Error.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Fatal($"Fatal.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Warn($"Warn.{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            Console.WriteLine("\n\n");
            using(StreamWriter logWriter=new StreamWriter("Log4netWriter.txt",true,Encoding.UTF8))
            {
                logWriter.WriteLine(logBuilder.ToString());
            }
        }
        static void ThreadDemo()
        {
            Console.WriteLine($"New thread start.{Thread.CurrentThread.ManagedThreadId}");
            Thread timerThread = new Thread(() =>
              {
                  System.Timers.Timer threadTimer = new System.Timers.Timer(10000.0);
                  threadTimer.Elapsed += ThreadTimer_Elapsed;
                  threadTimer.Start();
              });
            timerThread.Start();
            timerThread.Join();
            Console.WriteLine($"New thread finished.{Thread.CurrentThread.ManagedThreadId}");
        }
        private static void ThreadTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime);
        }
        static void NewtonDemo()
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                var dbSales = db.SalesOrderDetails.ToList();
                string newtonString = JsonConvert.SerializeObject(dbSales, Formatting.Indented);
                using (StreamWriter stringWriter = new StreamWriter("JsonFile.Json", true, Encoding.UTF8))
                {
                    stringWriter.WriteLine(newtonString);
                }
                Console.WriteLine(newtonString);
            }
        }
    }
}
