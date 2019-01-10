using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp315
{
    class Program
    {
        static Stopwatch watch = new Stopwatch();
        static int exportNum = 0;
        static string logPath = Directory.GetCurrentDirectory() + "\\ExportLog.txt";
        static string exportMsg = "";
        [STAThread]
        static void Main(string[] args)
        {
            Thread exportThread = new Thread(() =>
              {
                  using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
                  {
                      List<SalesOrderDetail> orderList = db.SalesOrderDetails.ToList();
                      orderList.AddRange(orderList);
                      orderList.AddRange(orderList);                      
                      ExportTEntity<SalesOrderDetail>(orderList.ToArray());
                  }
              });

            exportThread.SetApartmentState(ApartmentState.STA);
            exportThread.Start();
            exportThread.Join();
           
            System.Windows.Forms.MessageBox.Show(exportMsg);
            Console.ReadLine();
        }    
       
        [STAThread]
        static void ExportTEntity<T>(T[] arr)
        {            
            if (arr != null && !arr.Any())
            {
                return;
            }
            exportNum = arr.Length;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                watch.Start();
                XSSFWorkbook book;
                sfd.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)| *.xlsx | All Files | *.*";
                sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + Guid.NewGuid().ToString() + ".xlsx";
                sfd.InitialDirectory = Directory.GetCurrentDirectory();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var firstRowData = arr.FirstOrDefault();
                    book = new XSSFWorkbook();
                    var sheet = book.CreateSheet("Sheet1");
                    var firstRow = sheet.CreateRow(0);
                    var propertiesArr = firstRowData.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToArray();
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
                            var indexColumnName = propertiesArr[j];
                            var columnValue = indexColumnName.GetValue(arr[i - 1]);
                            if (columnValue != null)
                            {                                 
                                indexColumn.SetCellValue(columnValue.ToString());
                            }
                        }
                    }                     
                    using (FileStream stream = File.OpenWrite(sfd.FileName))
                    {
                        book.Write(stream);
                        stream.Close();
                    }
                    watch.Stop();
                    exportMsg = string.Format($"Saved in {sfd.FileName}.\nThere are totally {exportNum} salesorderdetails and cost {watch.ElapsedMilliseconds} millseconds and now is {DateTime.Now.ToString("yyyyMMddHHmmssfff")} \n\n");
                    File.AppendAllText(logPath, exportMsg);
                }
                arr = null;
            }
        }
    }     
}
