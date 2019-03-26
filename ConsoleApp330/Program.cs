using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text;
using System.Data;
using iTextSharp.text.pdf;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ConsoleApp330
{
    delegate void AsyncFoo(int i);
    class Program
    {
        static string excelFullName = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx";
        static string logFullName = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        static Stopwatch stopWatch = new Stopwatch();
        static string exportMsg = "";
        static object lockObj = new object();
        static void Main(string[] args)
        {
            PrintCurrentThreadInfo("Main()");

            PostAsync();

            Console.ReadLine();
        }

        static void ExportSalesData()
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                var dataList = db.SalesOrderDetails.ToList();  
                ExportTData<SalesOrderDetail>(dataList);
            }
        }
        static void ExportTData<T>(List<T> dataList)
        {
            if (dataList == null || !dataList.Any())
            {
                return;
            }

            try
            {
                stopWatch.Start();
                var firstRowData = dataList.FirstOrDefault();
                var props = firstRowData.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).ToList();
                XSSFWorkbook workBook = new XSSFWorkbook();
                ISheet firstSheet = workBook.CreateSheet("First Sheet");
                IRow headerRow = firstSheet.CreateRow(0);
                if (props != null && props.Any())
                {
                    for (int headerColumn = 0; headerColumn < props.Count; headerColumn++)
                    {
                        ICell headerCell = headerRow.CreateCell(headerColumn);
                        string headerName = props[headerColumn].Name;
                        if (!string.IsNullOrEmpty(headerName))
                        {
                            headerCell.SetCellValue(headerName);
                        }
                    }
                }

                for (int i = 0; i < dataList.Count; i++)
                {
                    IRow dataRow = firstSheet.CreateRow(i + 1);
                    for (int j = 0; j < props.Count; j++)
                    {
                        ICell dataCell = dataRow.CreateCell(j);

                        if (i == 0)
                        {
                            firstSheet.AutoSizeColumn(j);
                        }

                        var cellValue = props[j].GetValue(dataList[i]);
                        if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                        {
                            dataCell.SetCellValue(cellValue.ToString());
                        }
                    }
                }               

                using (FileStream excelStream = File.Open(excelFullName, FileMode.OpenOrCreate))
                {
                    workBook.Write(excelStream);
                }              

                stopWatch.Stop();
                exportMsg = $"{dataList.Count,-7} rows data,cost {stopWatch.ElapsedMilliseconds,-7} milliseconds," +
                    $"memory {Process.GetCurrentProcess().PrivateMemorySize64,-12} bytes, now is {DateTime.Now.ToString("yyyyMMddHHmmssffff"),-30}";
                LogMessage(exportMsg);
            }
            catch (Exception ex)
            {
                LogMessage(ex.StackTrace);
            }
        }
        static void LogMessage(string logMsg)
        {
            using (StreamWriter logWriter = new StreamWriter(logFullName, true))
            {
                logWriter.WriteLine(logMsg + Environment.NewLine);
            }
        }
        static DataTable GetDataTableFromList()
        {
            DataTable dt = new DataTable();
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                var dataList = db.SalesOrderDetails.ToList();
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);
                dataList.AddRange(dataList);

                stopWatch.Restart();
                dt = ConvertListToDataTable<SalesOrderDetail>(dataList);
                stopWatch.Stop();
                exportMsg = $"{dataList.Count,-7} rows data,cost {stopWatch.ElapsedMilliseconds,-7} milliseconds," +
                    $"memory {Process.GetCurrentProcess().PrivateMemorySize64,-12} bytes,now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
                LogMessage(exportMsg);
            }
            return dt;
        }
        static DataTable ConvertListToDataTable<T>(List<T> dataList)
        {           
            if(dataList==null || !dataList.Any())
            {
                return null;
            }

            try
            {
                DataTable dt = new DataTable();

                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (var dl in dataList)
                {
                    DataRow dtRow = dt.NewRow();
                    foreach (PropertyDescriptor prop in props)
                    {
                        dtRow[prop.Name] = prop.GetValue(dl) ?? DBNull.Value;
                    }
                    dt.Rows.Add(dtRow);
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogMessage(ex.StackTrace.ToString());
            }
            return null;           
        }
        static void ExportToPDF(DataTable dt)
        {
            Document pdfDoc = new Document(PageSize.A2);
            MemoryStream memStream = new MemoryStream();
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, memStream);

        }
        static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            binFormatter.Serialize(ms, obj);
            return ms.ToArray();
        }

        static void PrintCurrentThreadInfo(string name)
        {
            string isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread ? "" : " not "
                + " thread pool thread";
            Console.WriteLine("Thread Id of "+ name+" is "+ Thread.CurrentThread.ManagedThreadId  +
                ",current thread is " + (Thread.CurrentThread.IsThreadPoolThread ? "":" not ")+ " thread pool thread");  
        }

        static void Foo(int i)
        {
            PrintCurrentThreadInfo("Foo()");
            Thread.Sleep(i);
        }

        static void PostAsync()
        {
            AsyncFoo caller = new AsyncFoo(Foo);
            caller.BeginInvoke(1000, new AsyncCallback(FooCallBack), caller);
        }

        static void FooCallBack(IAsyncResult ar)
        {
            PrintCurrentThreadInfo("FooCallBack()");
            AsyncFoo caller = (AsyncFoo)ar.AsyncState;
            caller.EndInvoke(ar);
        }
    }
}
