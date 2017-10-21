using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ConsoleApp80
{
     
    //boiler 类
    class Boiler
    {
        private int temp;
        private int pressure;
        public Boiler(int t,int p)
        {
            temp = p;
            pressure = p;
        }

        public int GetTemp()
        {
            return temp;
        }

        public int GetPressure()
        {
            return pressure;
        }
    }

    //事件发布器
    class DelegateBoilerEvent
    {
        public delegate void BoilderLogHandler(string status);

        //基于上面的委托定义事件
        public event BoilderLogHandler BoilerEventLog;

        public void LogProcess()
        {
            string remarks = "O.K";
            Boiler boiler = new Boiler(100, 12);
            int t = boiler.GetTemp();
            int p = boiler.GetPressure();

            if(t>150||t<80||p<12||p>15)
            {
                remarks = "Need Maintenance";
            }
        }

        protected void OnBoilerEventLog(string msg)
        {
            if(null!=BoilerEventLog)
            {
                BoilerEventLog(msg);
            }
        }
    }

    //该类保留写入日志文件的条款
    class BoilerInfoLogger
    {
        FileStream fs;
        StreamWriter sw;
        public BoilerInfoLogger()
        {
            fs = new FileStream(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\msg.txt", FileMode.Append, FileAccess.Write);
            sw =new StreamWriter(fs);
        }

        public void Logger(string info)
        {
            sw.WriteLine(info);
        }

        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }
   
    //事件订阅器
    public class RecordBoilerInfo
    {
        static void Logger(string info)
        {
            Console.WriteLine(info);
        }

        static void Main(string[] args)
        {
            BoilerInfoLogger fileLog = new BoilerInfoLogger();
            DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilderLogHandler(Logger);
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilderLogHandler(fileLog.Logger);

            boilerEvent.LogProcess();
            Console.WriteLine("\n");
            fileLog.Close();
            Console.ReadLine();

        }
    }
}
