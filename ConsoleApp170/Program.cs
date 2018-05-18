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
        static int tables0RowsCount = 0;
        static int tables1RowsCount = 0;
        static List<string> columnTables0List = new List<string>();
        static List<string> columnTables1List = new List<string>();
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["connString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string selectSql = "select * from AdventureWorks2014.Sales.Store;select * from AdventureWorks2014.Sales.Customer;select * from AdventureWorks2014.Sales.Currency";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSql, conn);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                if (ds != null)
                {
                    GetTableColumnsName(ds);
                }          
            }
            
            Console.ReadLine();
        }

        private static void GetTableColumnsName(DataSet ds)
        {
            if(ds!=null && ds.Tables[0].Rows.Count>0)
            {
                for(int i=0;i<ds.Tables[0].Columns.Count;i++)
                {
                    columnTables0List.Add(ds.Tables[0].Columns[i].ColumnName);
                }
            }

            if(columnTables0List!=null && columnTables0List.Any())
            {
                Console.WriteLine("There are {0} columns  in ds.Tables[0],they are:\n",columnTables0List.Count);
                columnTables0List.ForEach(x =>
                {
                    Console.WriteLine(x);
                });

                Console.WriteLine("\n\n\n\n\n");
            }

            if(ds!=null && ds.Tables[1].Rows.Count>0)
            {
                for(int i=0;i<ds.Tables[1].Columns.Count;i++)
                {
                    columnTables1List.Add(ds.Tables[1].Columns[i].ColumnName);
                }
            }

            if(columnTables1List!=null && columnTables1List.Count>0)
            {
                Console.WriteLine("There are {0} columns  in ds.Tables[1],they are:\n",columnTables1List.Count);
                columnTables1List.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }
        }
    }
}
