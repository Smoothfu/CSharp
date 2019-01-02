using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;

namespace ConsoleApp314
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                //SalesOrderDetail[] storeArr = db.SalesOrderDetails.ToArray();
                //ExportTEntity<SalesOrderDetail>(storeArr);
                Store[] arr = db.Stores.ToArray();
                ExportTEntity<Store>(arr);
            }

            Console.ReadLine();
        }

        static void DbEntity()
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                var stores = db.Stores;
                if (stores != null && stores.Any())
                {
                    foreach (var s in stores)
                    {
                        Console.WriteLine($"{s.BusinessEntityID},{s.ModifiedDate},{s.Name},{s.rowguid}");
                    }
                }
            }
        }

        static void StreamWriterLog()
        {
            using (StreamWriter writer = new StreamWriter("myLog5.txt"))
            {
                DateTime dt = DateTime.Now;
                DateTime endDt = dt.AddSeconds(5);
                while (DateTime.Now < endDt)
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                }

                System.Windows.Forms.MessageBox.Show("Completed!");
            }
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


        static void ExportTEntity<T>(T [] arr)
        {
            if(arr!=null && !arr.Any())
            {
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
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
                            var columnValue = arr[i - 1].GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToArray()[j].GetValue(arr[i - 1]).ToString();

                            indexColumn.SetCellValue(columnValue);
                        }
                    }

                    using (var excelStream = new FileStream(savedExcelFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        book.Write(excelStream);
                        excelStream.Close();
                    }

                    System.Windows.Forms.MessageBox.Show("Completed!");
                }
            }
        }
        public class IPAddresses : DictionaryBase
        {
            public IPAddresses()
            {

            }

            public void Add(string name, string ip)
            {
                base.InnerHashtable.Add(name, ip);
            }

            public string Item(string name)
            {
                return base.InnerHashtable[name].ToString();
            }

            public void Remove(string name)
            {
                base.InnerHashtable.Remove(name);
            }
        }
    }
}
