using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LogService.svc or LogService.svc.cs at the Solution Explorer and start debugging.
    public class LogService : ILogService
    {
        readonly string logFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        public string CreateLogFile(string fileName)
        {
            if (!File.Exists(logFullName))
            {
                File.CreateText(logFullName);
            }
            return logFullName;
        }

        public void LogMessage(string logMsg)
        {
            using (StreamWriter logWriter = new StreamWriter(logFullName, true))
            {
                logWriter.WriteLine(logMsg);
                logWriter.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssfff")}");
            }
        }
    }
}
