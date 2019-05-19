using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF;
using System.Reflection;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using System.Windows.Forms;

namespace ConsoleApp347.DAO
{
    public class ExportTByNPOI
    {
        [STAThread]
        public static void ExportTDataByNPOI<T>(List<T> dataList,string fileName)
        {
            if(dataList!=null && dataList.Any())
            {
                var firstData = dataList.FirstOrDefault();
                var props = firstData.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToList();
                XSSFWorkbook workbook = new XSSFWorkbook();
                ISheet firstSheet = workbook.CreateSheet("First Sheet");
                IRow firstRow = firstSheet.CreateRow(0);
                for(int i=0;i<props.Count;i++)
                {
                    ICell headerCell = firstRow.CreateCell(i);
                    if(!string.IsNullOrEmpty(props[i].Name))
                    {
                        headerCell.SetCellValue(props[i].Name);
                    }
                }
                for(int i=1;i<=dataList.Count;i++)
                {
                    IRow dataRow = firstSheet.CreateRow(i);
                    for(int j=0;j<props.Count;j++)
                    {
                        ICell dataCell = dataRow.CreateCell(j);
                        var dataCellValue = props[j].GetValue(dataList[i - 1]);
                        if(dataCellValue!=null)
                        {
                            dataCell.SetCellValue(dataCellValue.ToString());
                        }
                    }
                }

                using (FileStream excelStream = File.Open(fileName,FileMode.OpenOrCreate))
                {
                    workbook.Write(excelStream);
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files| *.xls; *.xlsx; *.xlsm|All files|*.*";
                sfd.FileName = fileName;
                sfd.OverwritePrompt = false;
               
                if (sfd.ShowDialog()==DialogResult.OK)
                {
                    sfd.FileName = fileName;
                }
            }

        }
    }
}
