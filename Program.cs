using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp351
{
    delegate void MyDel();

    delegate void AddDel (int x, int y);
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        static volatile bool isStop = false;
        static void Main(string[] args)
        {
            GetSQLResult();
            Console.ReadLine();
        }

        static void TaskCancellation(object obj)
        {
            if (isStop)
            {
                return;
            }
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")};");
            Thread.Sleep(1000);
        }
        private static void AddCallback(IAsyncResult ar)
        {
            var iasynResult = ar.AsyncState;
            Console.WriteLine(iasynResult.ToString());
        }
        static void AddMethod(int x, int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}");
        }
        private static void DelCallback(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState);
        }
        static void MyMethod()
        {
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")};");
        }
        static void GetSQLResult()
        {            
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string executeFunc = "select ROUTINE_NAME,ROUTINE_DEFINITION from INFORMATION_SCHEMA.ROUTINES  where ROUTINE_TYPE='function' ";
                using (SqlCommand cmd = new SqlCommand(executeFunc, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        StringBuilder sqlBuilder = new StringBuilder();
                        for(int i=0;i<sqlDataReader.FieldCount;i++)
                        {
                            sqlBuilder.Append(sqlDataReader[i].ToString());
                        }
                        Console.WriteLine(sqlBuilder.ToString()+"\n");
                    }
                }
            }
        }
    }
}
