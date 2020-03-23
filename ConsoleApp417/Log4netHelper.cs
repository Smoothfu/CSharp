using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp417
{
    public  class Log4netHelper
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static object logLock = new object();
        public static void LogInfo(string msg)
        {
            lock(logLock)
            {
                logger.Info(msg);
            }            
        }

        public static void LogError(string msg)
        {
            lock(logLock)
            {
                logger.Error(msg);
            }           
        }

        public static void LogDebug(string msg)
        {
            lock(logLock)
            {
                logger.Debug(msg);
            }            
        }

        public static void LogWarn(string msg)
        {    
            lock(logLock)
            {
                logger.Warn(msg);
            }            
        }
    }
}
