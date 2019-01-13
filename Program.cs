using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace ConsoleApp318
{
    class Program
    {
        static string csvFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".csv";
        static string logFileName = ".\\" + DateTime.Now.ToString("yyyyMMdd") + "log.txt";
        static Stopwatch stopWatch = new Stopwatch();
        static string exportMsg = "";
        [STAThread]
        static void Main(string[] args)
        {
            Thread exportThread = new Thread(() =>
            {
                using (AdventureWorks2017Entities context = new AdventureWorks2017Entities())
                {
                    List<SalesOrderDetail> orderList = context.SalesOrderDetails.ToList();
                    orderList.AddRange(orderList);
                    orderList.AddRange(orderList);
                    orderList.AddRange(orderList);
                    orderList.AddRange(orderList);
                    ExportByCSV<SalesOrderDetail>(orderList);
                }
            });
            exportThread.SetApartmentState(ApartmentState.STA);
            exportThread.Start();
            exportThread.Join();

            MessageBox.Show(exportMsg);

            Console.ReadLine();
        }

        static void ExportByCSV<T>(List<T> dataList)
        {
            StringBuilder exportBuilder = new StringBuilder();
            if (dataList == null && !dataList.Any())
            {
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = csvFileName;
                sfd.Filter = "Csv Files|*.csv|All Files|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    stopWatch.Start();
                    var firstRowData = dataList.FirstOrDefault();
                    var properties = firstRowData.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToList();
                    exportBuilder.Append(string.Join(",", properties.Select(x => x.Name)) + Environment.NewLine);
                    foreach (var dl in dataList)
                    {
                        for (int i = 0; i < properties.Count() - 1; i++)
                        {
                            var prop = properties[i];
                            exportBuilder.Append(prop.GetValue(dl) + ",");
                        }
                        exportBuilder.Append(properties[properties.Count - 1].GetValue(dl) + Environment.NewLine);
                    }

                    using (StreamWriter writer = new StreamWriter(sfd.FileName))
                    {
                        writer.WriteLine(exportBuilder.ToString());
                    }

                    stopWatch.Stop();
                    exportMsg = $"There are {dataList.Count} rows data and cost {stopWatch.ElapsedMilliseconds} milliseconds";
                    File.AppendAllText(logFileName, exportMsg + Environment.NewLine);
                }
            }
        }
    }
}
