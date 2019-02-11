using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp323
{
    class Program
    {
        static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        static string selectSQL = @"select SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber,OrderQty,
            ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,rowguid,ModifiedDate from sales.SalesOrderDetail";
        static Stopwatch stopwatch = new Stopwatch();
        static string exportMsg = "";
        static int exportNum = 0;
        static string logFullName = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMdd") + "log.txt";
        static void Main(string[] args)
        {
            SqlDataReaderDB();
            Console.ReadLine();
        }

        static void SqlDataAdapterDB()
        {
            stopwatch.Restart();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand selectCmd = new SqlCommand(selectSQL, conn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            exportNum++;
                            string rowMsg = $"{ds.Tables[0].Rows[i][0],-10}{ds.Tables[0].Rows[i][1],-10}" +
                                 $"{ds.Tables[0].Rows[i][2],-15}{ds.Tables[0].Rows[i][3],-5}" +
                                 $"{ds.Tables[0].Rows[i][4],-5}{ds.Tables[0].Rows[i][5],-5}" +
                                $"{ds.Tables[0].Rows[i][6],-10}{ds.Tables[0].Rows[i][7],-10}" +
                                $"{ds.Tables[0].Rows[i][8],-15}{ds.Tables[0].Rows[i][9],-45}" +
                                $"{ds.Tables[0].Rows[i][10],-30}";
                            Console.WriteLine(rowMsg); 
                        }
                    }
                }
            }

            stopwatch.Stop();
            exportMsg = $"SqlDataAdapter cost:{stopwatch.ElapsedMilliseconds} milliseconds,export number:{exportNum}," +
                $"now:{DateTime.Now.ToString("yyyyMMddHHmmssfff")},memory:{Process.GetCurrentProcess().PrivateMemorySize64}";
            LogMessage(exportMsg);
        }

        static void SqlDataReaderDB()
        {
            exportNum = 0;
            stopwatch.Restart();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(selectSQL, conn))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        exportNum++;
                        string dataReaderMsg = $"{dataReader[0],-10}{dataReader[1],-10}{dataReader[0],-10}" +
                            $"{dataReader[2],-15}{dataReader[3],-5}{dataReader[4],-5}{dataReader[5],-5}{dataReader[6],-10}" +
                            $"{dataReader[7],-10}{dataReader[8],-15}{dataReader[9],-45}{dataReader[0],-30}";
                        Console.WriteLine(dataReaderMsg);
                    }
                  }
            }
            stopwatch.Stop();
            exportMsg = $"SqlDataReader cost:{stopwatch.ElapsedMilliseconds} milliseconds,export number:{exportNum}" +
                $"now:{DateTime.Now.ToString("yyyyMMddHHmmssfff")},memory:{Process.GetCurrentProcess().PrivateMemorySize64}";
            LogMessage(exportMsg);
            
        }

        static void LogMessage(string logMsg)
        {
            using (StreamWriter streamWriter = new StreamWriter(logFullName, true))
            {
                streamWriter.WriteLine(logMsg);
            }
        }
    }
}
