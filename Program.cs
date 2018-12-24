using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI;
using NPOI.OpenXml4Net;
using System.Threading;
using NPOI.HSSF.UserModel;
using System.IO;

namespace ConsoleApp313
{
    class Program
    { 
        [STAThread]
        static void Main(string[] args)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                Store[] storesList = db.Stores.ToArray();
                if(storesList!=null && storesList.Any())
                {
                    Thread thread = new Thread(() =>
                    {
                        ExportEntityStoresByNPOI(storesList);
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
               
            }
              
            Console.ReadLine();
        }
        static void ExportEntityStoresByNPOI(Store[] storesArr)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                Store firstStore = db.Stores.ToList().FirstOrDefault();
                SaveFileDialog sfd = new SaveFileDialog();
                List<string> columnsList = new List<string>();
                HSSFWorkbook book;
                string savedExcelFileName;
                sfd.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)| *.xlsx | All Files | *.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    book = new HSSFWorkbook();
                    var sheet = book.CreateSheet("Sheet1");
                    savedExcelFileName = sfd.FileName;
                    var firstRow = sheet.CreateRow(0);


                    var propertiesNum = typeof(Store).GetProperties().Count();
                    for (int i = 0; i < propertiesNum; i++)
                    {
                        var column = firstRow.CreateCell(i);
                        column.SetCellValue((typeof(Store).GetProperties()[i]).Name);
                        columnsList.Add((typeof(Store).GetProperties()[i]).Name);
                    }

                    for (int i = 1; i <= storesArr.Count(); i++)
                    {
                        var indexRow = sheet.CreateRow(i);
                        for (int j = 0; j < propertiesNum; j++)
                        {                           
                            var indexColumn = indexRow.CreateCell(j);
                            var columnValue = storesArr[i - 1].Name;                      
                            
                            indexColumn.SetCellValue(columnValue);
                        }
                    }

                    using (var excelStream = new FileStream(savedExcelFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        book.Write(excelStream);
                        excelStream.Close();
                    }
                }
            }
        }
    }
}
