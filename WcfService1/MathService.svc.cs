using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IMathService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IMathService.svc or IMathService.svc.cs at the Solution Explorer and start debugging.
    public class MathService : IMathService
    {
        public LogService LogServiceInstance { get; set; }
        public MathService()
        {
            LogServiceInstance = new LogService();
        }
        public MathService(LogService logServiceObj)
        {
            LogServiceInstance = logServiceObj;
        }
        public string Add(int x, int y)
        {
            try
            {
                return string.Format($"{x}+{y}={x + y}");
            }
            catch(Exception ex)
            {
                LogServiceInstance.LogMessage(ex.StackTrace);
                return ex.StackTrace;
            }            
        }        

        public string Multiply(int x, int y)
        {
            try
            {
                return string.Format($"{x}/{y}={x / y}");
            }
            catch(Exception ex)
            {
                LogServiceInstance.LogMessage(ex.StackTrace);
                return ex.Message;
            }            
        }

        public string Divide(int x, int y)
        {
            try
            {
                return string.Format($"{x}/{y}={x / y}");
            }
            catch(Exception ex)
            {
                LogServiceInstance.LogMessage(ex.StackTrace);
                return ex.Message;
            }
        }
    }
}
