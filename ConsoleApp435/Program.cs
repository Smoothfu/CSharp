using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using Newtonsoft.Json;

namespace ConsoleApp435
{
    class Program
    {
        static int i = 0;
        static int j = 0;
        static void Main(string[] args)
        {
            EFDemo();              
        }

        static void EFDemo()
        {
            using(AdventureWorks2017Entities db=new AdventureWorks2017Entities())
            {
                string jsonValue = JsonConvert.SerializeObject(db.SalesOrderDetails.ToList(), Formatting.Indented);
                LogMsg("Db.json", jsonValue);
            }
        }

        static void SQLDemo()
        {
            string connString = ConfigurationManager.AppSettings["SqlConnString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                if(conn.State==ConnectionState.Open)
                {
                    string selectSQL = "select * from sales.SalesOrderDetail;";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSQL, conn);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    StringBuilder tableBuilder = new StringBuilder();
                    if(ds.Tables!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                    {
                        int rowsCount = ds.Tables[0].Rows.Count;
                        int colsCount = ds.Tables[0].Columns.Count;
                        for(int i=0;i<rowsCount;i++)
                        {
                            StringBuilder sqlBuilder = new StringBuilder();
                            for(int j=0;j<colsCount;j++)
                            {
                                sqlBuilder.Append(ds.Tables[0].Rows[i][j]?.ToString()+",");
                            }
                            string rowResult = sqlBuilder.ToString().Remove(sqlBuilder.ToString().LastIndexOf(","));
                            //Console.WriteLine(rowResult);
                            tableBuilder.AppendLine(rowResult);
                        }
                    }
                    LogMsg("TableResult.txt",tableBuilder.ToString());
                }
            }
        }

        static void WhileDemo()
        {
            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    WhileStopwatchElapsed();
                    WhileLoopDatetime();
                }
            });
        }

        static void WhileStopwatchElapsed()
        {
            i = 0;
            Console.WriteLine("WhileStopwatchElapsed() started!");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while(sw.Elapsed<TimeSpan.FromSeconds(10))
            {
                i++;
            }
            string msg=$"{ DateTime.Now.ToString("yyyyMMddHHmmssffff")},in WhileStopwatchElapsed() i is {i} ";
            FileWriteMsg(msg);
            Console.WriteLine(msg);
            Console.WriteLine("WhileStopwatchElapsed() ended!");
        }

        static void WhileLoopDatetime()
        {
            j = 0;
            Console.WriteLine("WhileLoopDatetime() started!");
            var startTime = DateTime.UtcNow;
            while(DateTime.UtcNow-startTime<TimeSpan.FromSeconds(10))
            {
                j++;
            }
            string msg = $"{ DateTime.Now.ToString("yyyyMMddHHmmssffff")},in WhileLoopDatetime() j is {j}";
            FileWriteMsg(msg);
            Console.WriteLine(msg);
            Console.WriteLine("WhileLoopDatetime() ended!");
        }

        static void FileWriteMsg(string msg)
        {            
            File.AppendAllText("dt.txt", msg+Environment.NewLine);
        }

        static void LogMsg(string fileName,string msg)
        {
            using(StreamWriter logWriter=new StreamWriter(fileName,true,Encoding.UTF8))
            {
                logWriter.WriteLine(msg);
            }
        }
    }
}
