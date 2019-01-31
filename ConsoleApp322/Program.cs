using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp322
{
    class Program
    {
        static string cvsFileFullName = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".csv";
        static string fullLogFileName = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMdd") + "log.txt";
        static Stopwatch stopWatch = new Stopwatch();
        static int exportNumber = 0;
        static void Main(string[] args)
        {
            ExportTToCVS();
        }

        static void ExportTToCVS()
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                List<SalesOrderDetail> orderList = db.SalesOrderDetails.ToList();
                var tempList = orderList.Take(1000000).ToList();
                orderList.AddRange(orderList);
                orderList.AddRange(orderList);
                orderList.AddRange(orderList);
                orderList.AddRange(orderList);
                orderList.AddRange(orderList);
                orderList.AddRange(orderList);
                orderList.AddRange(tempList);
                ExportListTToCVS<SalesOrderDetail>(orderList);
            }
        }

        static void ExportListTToCVS<T>(List<T> dataList)
        {

            if(dataList!=null && dataList.Any())
            {
                stopWatch.Start();
                exportNumber = dataList.Count;
                StringBuilder orderBuilder = new StringBuilder();
                var firstRowData = dataList.FirstOrDefault();
                var orderProps = firstRowData.GetType().GetProperties().ToList();
                orderBuilder.AppendLine(string.Join(",", orderProps.Select(x=>x.Name).ToArray()));
                foreach(var dl in dataList)
                {
                    orderBuilder.Append(dl.ToString());
                }

                using (StreamWriter streamWriter = new StreamWriter(cvsFileFullName))
                {
                    streamWriter.WriteLine(orderBuilder.ToString());
                }

                stopWatch.Stop();
                Process proc = Process.GetCurrentProcess();
                long exportMemory = proc.PrivateMemorySize64;
                string exportMsg = $"File path:{cvsFileFullName},export number:{exportNumber}," +
                    $"cost: {stopWatch.ElapsedMilliseconds} milliseconds,memory:{exportMemory}";
                File.AppendAllText(fullLogFileName, exportMsg + Environment.NewLine);
            }
        }
    }
}
