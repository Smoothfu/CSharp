using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp170
{
    class Program
    {
        static int rowsCount = 0;
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["connString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                string selectSql = "select * from AdventureWorks2014.Sales.Store";
                SqlCommand sqlCmd = new SqlCommand(selectSql, conn);
                SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    rowsCount++;
                    for(int i=0;i<sqlDataReader.FieldCount;i++)
                    {
                        Console.WriteLine(sqlDataReader[i]);
                    }
                    Console.WriteLine("\n\n\n\n\n");
                }
            }

            Console.WriteLine("\n\nThere are {0} rows in the table", rowsCount);
            Console.ReadLine();
        }
    }
}
