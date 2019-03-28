using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ConsoleApp332
{
    class Program
    {
        static int i = 0;
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Task<string> stringTask = Task<string>.Run<string>(() => RetrieveString(),cts.Token);

            string result = stringTask.Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static void Add(object obj)
        {
            try
            {
                while (i < 100)
                {
                    while (i == 90)
                    {
                        cts.Cancel();
                    }
                    string msg = $"i {i},Guid:{Guid.NewGuid()}";
                    Console.WriteLine(msg);
                    Logger.WriteLog(msg);
                    i++;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                  
        }

        static string RetrieveString()
        {
            string msg = $"i {i},Guid:{Guid.NewGuid()}";
            cts.Cancel();
            return msg;
        }
    }

    public static class Logger
    {
        private static string lockString = "lockString";
        private static string logFullPath = Directory.GetCurrentDirectory() + "\\"
            + DateTime.Now.ToString("yyyyMMdd");
        
        public static void WriteLog(string logMessage)
        {   
            lock(lockString)
            {
                using (StreamWriter logWriter = new StreamWriter(logFullPath, true, Encoding.UTF8))
                {

                    logWriter.WriteLine(logMessage);
                }
            }            
        }
    }
}
