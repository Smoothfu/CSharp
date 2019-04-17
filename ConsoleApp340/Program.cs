using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp340
{
    class Program
    {
        static string logFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        static int runTimes;
        static string runMsg;
        static int secondsSpan;
        static void Main(string[] args)
        {
            secondsSpan = 150;
            TaskRun();
            TaskFactoryStartNew();
        }

        static void TaskRun()
        {
            runTimes = 0;
            DateTime dtNow = DateTime.Now;
            DateTime dtEnd = dtNow.AddSeconds(secondsSpan);
            Task runTask = Task.Run(() =>
            {
                while (DateTime.Now < dtEnd)
                {
                    Debug.WriteLine($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")},guid is {Guid.NewGuid()}");
                    runTimes++;
                }
            });
            runTask.Wait();
            runMsg = $"In {secondsSpan} seconds, TaskRun() it run {runTimes} times";
            LogMessage(runMsg);
        }

        static void TaskFactoryStartNew()
        {
            runTimes = 0;
            DateTime dtNow = DateTime.Now;
            DateTime dtEnd = dtNow.AddSeconds(secondsSpan);

            Task taskFactory = Task.Factory.StartNew(() =>
            {
                while (DateTime.Now < dtEnd)
                {
                    Debug.WriteLine($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")},guid is {Guid.NewGuid()}");
                    runTimes++;
                }
            });
            taskFactory.Wait();
            runMsg = $"In {secondsSpan} seconds,Task.Factory.StartNew() it run {runTimes} times";
            LogMessage(runMsg);
        }     

        static void LogMessage(string msg)
        {
            using (StreamWriter logStreamWriter = new StreamWriter(logFullName, true))
            {
                logStreamWriter.WriteLine(msg);
            }
        }
    }   
}
