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
        static List<string> columnList = new List<string>();
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
                        if(!columnList.Contains(sqlDataReader.GetName(i)))
                        {
                            columnList.Add(sqlDataReader.GetName(i));
                        }
                        
                    }
                    Console.WriteLine("\n\n\n\n\n");
                }
            }

             
            Console.WriteLine("\n\nThere are {0} rows in the table,and every row has {1} columns,and the column name:\n\n", rowsCount,columnList.Count);

            columnList.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            Console.ReadLine();
        }
    }
}
