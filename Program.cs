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
using System.Reflection;

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
                if (storesList != null && storesList.Any())
                {
                    Thread thread = new Thread(() =>
                    {
                        ExportEntityStoresByNPOI(storesList);
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }

                //PropertyInfo[] pis = storesList[0].GetType().GetProperties();

                //if(pis!=null && pis.Any())
                //{
                //    foreach(var item in pis)
                //    {
                //        var prop = item.GetValue(storesList[0]);

                //        Console.WriteLine($"{ item.Name}:{prop}");                      
                //    }
                //}

            }
            Console.ReadLine();
        }
        static void ExportEntityStoresByNPOI(Store[] storesArr)
        {
            Store firstStore = storesArr.FirstOrDefault();
            SaveFileDialog sfd = new SaveFileDialog();
            List<string> columnsList = new List<string>();
            HSSFWorkbook book;
            string savedExcelFileName;
            string sfdFilePath;
            sfd.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)| *.xlsx | All Files | *.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                book = new HSSFWorkbook();
                var sheet = book.CreateSheet("Sheet1");
                savedExcelFileName = sfd.FileName;
                sfdFilePath=Path.GetDirectoryName(savedExcelFileName);
                sfd.InitialDirectory = "";
                var firstRow = sheet.CreateRow(0);

                PropertyInfo[] piss = storesArr[0].GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToArray();
                 
                if(piss!=null && piss.Any())
                {
                    for(int i=0;i<piss.Count();i++)
                    {
                        var column = firstRow.CreateCell(i);
                        column.SetCellValue(piss[i].Name);
                    }
                }                 

                for (int i = 1; i <= storesArr.Count(); i++)
                {
                    var indexRow = sheet.CreateRow(i);
                    PropertyInfo[] pis = storesArr[i - 1].GetType().GetProperties().Where(x=>!x.GetMethod.IsVirtual).ToArray();

                    int columnIndex = 0;
                    if(pis!=null && pis.Any())
                    {
                        foreach(PropertyInfo pi in pis)
                        {
                            var columnValue = pi.GetValue(storesArr[i - 1]);
                            var column = indexRow.CreateCell(columnIndex);
                            
                            column.SetCellValue(columnValue.ToString());
                            columnIndex++;
                        }
                    }                    
                }

                using (var excelStream = new FileStream(savedExcelFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    book.Write(excelStream);
                    excelStream.Close();                   
                    System.Windows.Forms.MessageBox.Show($"{savedExcelFileName} saved in {sfdFilePath}");
                }
            } 
        }

        static void GetPersonList()
        {
            List<MyPersonSS> personList = new List<MyPersonSS>();
            for (int i = 0; i < 10; i++)
            {
                personList.Add(new MyPersonSS() { Name = "Fred" + i, Age = i });
            }

            if (personList.Any())
            {
                var secondAge = typeof(MyPersonSS).GetProperties()[1].GetValue(personList[2]);
            }
        }

    }

    public class MyPersonSS
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
