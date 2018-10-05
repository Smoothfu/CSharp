using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary4;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                WcfServiceLibrary4.Service1 client = new Service1();
                List<DataDesc> dbList = client.GetDBDescs();
                if (dbList != null && dbList.Any())
                {
                    dbList.ForEach(x =>
                    {
                        Console.WriteLine("TableCatalog:{0},TableSchema:{1},TableName:{2},TableType:{3}\n", x.TableCatalog, x.TableSchema, x.TableName, x.TableType);
                    });
                }

            });

            //string connString = @"server=FRED\SQLEXPRESS;database=AdventureWorks2014;Integrated Security=SSPI";
            //SqlConnection conn = new SqlConnection(connString);
            //if(conn.State!=ConnectionState.Open)
            //{
            //    conn.Open();
            //}

            Console.ReadLine();
        }
    }
}
