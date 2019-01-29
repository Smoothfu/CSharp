using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace ConsoleApp320
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AdventureWorks2012Entities db = new AdventureWorks2012Entities())
            {
                var allDetails = db.SalesOrderDetails.Take(10000).ToList();
                var firstOrderNames = allDetails.FirstOrDefault().GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToList();
                XSSFWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet();
                IRow firstRow = sheet.CreateRow(0);
                for (int i = 0; i < firstOrderNames.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(firstOrderNames[i].Name))
                    {
                        ICell cell = firstRow.CreateCell(i);
                        cell.SetCellValue(firstOrderNames[i].Name);
                    }
                }
                if (firstOrderNames!=null && firstOrderNames.Any())
                {
                    for(int i=0;i<allDetails.Count;i++)
                    {
                        IRow row = sheet.CreateRow(i + 1);
                        for(int j=0;j<firstOrderNames.Count;j++)
                        {
                            if (firstOrderNames[j].GetValue(allDetails[i]) != null)
                            {
                                ICell cell = row.CreateCell(j);
                                cell.SetCellValue(firstOrderNames[j].GetValue(allDetails[i]).ToString());
                            }
                        }                       
                    }
                }

                using (FileStream stream = File.OpenWrite(".\\export3.xlsx"))
                {
                    book.Write(stream);
                    stream.Close();
                    stream.Dispose();
                }

                Console.WriteLine($"There are totally {allDetails.Count} rows data");
                Console.ReadLine();
            }
        }
    }
}
