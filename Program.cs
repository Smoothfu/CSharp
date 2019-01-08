using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms; 
using NPOI.XSSF.UserModel;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace ConsoleApp314
{
    class Program
    {
        static Stopwatch watch = new Stopwatch();
        static int exportNum = 0;         
        static string logPath = Directory.GetCurrentDirectory()+"\\ExportLog.txt";

        [STAThread]
        static void Main(string[] args)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                List<SalesOrderDetail> dbSales = db.SalesOrderDetails.ToList();
                dbSales.AddRange(dbSales);
                dbSales.AddRange(dbSales);
                exportNum = dbSales.Count;
                SalesOrderDetail[] arr = dbSales.ToArray();
                dbSales = null;

                watch.Start();
                Task.Run(() =>
                {
                    string threadMsg = string.Format($"ThreadId:{Thread.CurrentThread.ManagedThreadId},Time is {DateTime.Now.ToString("yyyyMMddHHmmssffffff")} \n\n\n");
                    File.AppendAllText(logPath, threadMsg);
                    ExportTEntity<SalesOrderDetail>(arr);
                });
               
                Console.ReadLine();
            }
        }
        
        [STAThread]
        static void ExportTEntity<T>(T[] arr)
        {
            if (arr != null && !arr.Any())
            {
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                XSSFWorkbook book;
                sfd.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)| *.xlsx | All Files | *.*";
                sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmssffffff") +Guid.NewGuid().ToString() + ".xlsx";
                sfd.InitialDirectory = Directory.GetCurrentDirectory();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    book = new XSSFWorkbook();
                    var sheet = book.CreateSheet("Sheet1");
                    var firstRow = sheet.CreateRow(0);
                    var propertiesArr = typeof(T).GetProperties().Where(x => !x.GetMethod.IsVirtual).ToArray();
                    for (int i = 0; i < propertiesArr.Length; i++)
                    {
                        var column = firstRow.CreateCell(i);
                        column.SetCellValue(propertiesArr[i].Name);
                    }

                    for (int i = 1; i <= arr.Length; i++)
                    {
                        var indexRow = sheet.CreateRow(i);
                        for (int j = 0; j < propertiesArr.Length; j++)
                        {
                            var indexColumn = indexRow.CreateCell(j);
                            var indexColumnName = arr[i - 1].GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToArray()[j];

                            if (indexColumnName.GetValue(arr[i - 1]) != null)
                            {
                                var columnValue = indexColumnName.GetValue(arr[i - 1]).ToString();
                                indexColumn.SetCellValue(columnValue);
                            }
                        }
                    }
                    using (var excelStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        book.Write(excelStream);
                        excelStream.Close();
                    }

                    watch.Stop();
                    string exportMsg = string.Format($"There are totally {exportNum} salesorderdetails and cost {watch.ElapsedMilliseconds} millseconds and now is {DateTime.Now.ToString("yyyyMMddHHmmssfff")} \n\n");                
                    File.AppendAllText(logPath,exportMsg);
                    MessageBox.Show(exportMsg);
                }
                
                arr = null;
            }                   
        }
    }
}
