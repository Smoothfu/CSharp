using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace ConsoleApp315
{
    class ExportClass
    {
        //static void ExportByNPOI()
        //{
        //    watch.Start();
        //    using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
        //    {
        //        List<SalesOrderDetail> salesDetailList = db.SalesOrderDetails.ToList();

        //        Thread exportThread = new Thread(() =>
        //        {
        //            string threadMsg = string.Format($"ThreadId:{Thread.CurrentThread.ManagedThreadId},Time is {DateTime.Now.ToString("yyyyMMddHHmmssffffff")} \n\n\n");
        //            File.AppendAllText(logPath, threadMsg, Encoding.UTF8);
        //            InvokeExportByNPOI<SalesOrderDetail>(salesDetailList.ToArray());
        //        });
        //        exportThread.SetApartmentState(ApartmentState.STA);
        //        exportThread.Start();
        //        exportThread.Join();
        //    }
        //}
        //static void InvokeExportByNPOI<T>(T[] arr)
        //{
        //    if (arr != null && !arr.Any())
        //    {
        //        return;
        //    }

        //    string excelName = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + Guid.NewGuid().ToString() + ".xlsx";
        //    XSSFWorkbook book = new XSSFWorkbook();
        //    var sheet = book.CreateSheet("Sheet1");
        //    var firstRow = sheet.CreateRow(0);
        //    var propertiesArr = typeof(T).GetProperties().Where(x => !x.GetMethod.IsVirtual).ToArray();
        //    for (int i = 0; i < propertiesArr.Length; i++)
        //    {
        //        var column = firstRow.CreateCell(i);
        //        column.SetCellValue(propertiesArr[i].Name);
        //    }


        //    using (FileStream fs = new FileStream(excelName, FileMode.Append))
        //    {
        //        for (int time = 0; time < 10; time++)
        //        {
        //            watch.Start();
        //            exportNum += 10;
        //            for (int i = time * 10 + 1; i <= time * 10 + 10; i++)
        //            {
        //                var indexRow = sheet.CreateRow(i);
        //                for (int j = 0; j < propertiesArr.Length; j++)
        //                {
        //                    var indexColumn = indexRow.CreateCell(j);
        //                    var indexColumnName = arr[i % 10].GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToArray()[j];

        //                    if (indexColumnName.GetValue(arr[i % 10]) != null)
        //                    {
        //                        var columnValue = indexColumnName.GetValue(arr[i % 10]).ToString();
        //                        indexColumn.SetCellValue(columnValue);
        //                    }
        //                }
        //            }
        //            book.Write(fs);
        //            watch.Stop();
        //            string exportMsg = string.Format($"Saved in {excelName}.\nThere are totally {exportNum} salesorderdetails and cost {watch.ElapsedMilliseconds} millseconds and now is {DateTime.Now.ToString("yyyyMMddHHmmssfff")} \n\n");
        //            File.AppendAllText(logPath, exportMsg, Encoding.UTF8);
        //        }
        //        fs.Close();
        //    }
        //}
    }
}
