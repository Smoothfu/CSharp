using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace WpfApp46.Common
{
    public static class CommonHelper
    {
        public static void ExportDataTable(DataTable dt, string excelFullName = null)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet firstSheet = workbook.CreateSheet("First Sheet");
            IRow headerRow = firstSheet.CreateRow(0);
            for(int i=0;i<dt.Columns.Count;i++)
            {
                ICell headerCell = headerRow.CreateCell(i);
                headerCell.SetCellValue(dt.Columns[i].ColumnName);
            }

            for(int i=0;i<dt.Rows.Count;i++)
            {
                IRow dataRow = firstSheet.CreateRow(i + 1);
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    ICell dataCell = dataRow.CreateCell(j);
                    dataCell.SetCellValue(dt.Rows[i][j]?.ToString());
                }
            }

            if(string.IsNullOrEmpty(excelFullName))
            {
                excelFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xlsx";
            }

            using (FileStream excelStream=File.OpenWrite(excelFullName))
            {
                workbook.Write(excelStream, true);
            }
        }
    }
}
