using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;

namespace ConsoleApp410
{
    class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         
        static void Main(string[] args)
        {
            for(int i=0;i<1000000;i++)
            {
                Log4netDemo();
            }
            Console.ReadLine();
        }

        static void Log4netDemo()
        {
            logger.Info($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Error($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Debug($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Fatal($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            logger.Warn($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
        }
    }
}
