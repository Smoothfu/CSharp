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

            if(conn.State==ConnectionState.Open)
            {
                string selectSql = "select * from AdventureWorks2014.Sales.Store;select * from AdventureWorks2014.Sales.Customer;select * from AdventureWorks2014.Sales.Currency";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSql, conn);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);

                if(ds.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        tables0RowsCount++;
                        for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                        {
                            if(!columnTables0List.Contains(ds.Tables[0].Columns[j].ColumnName))
                            {
                                columnTables0List.Add(ds.Tables[0].Columns[j].ColumnName);
                            }
                            
                            Console.WriteLine("{0,-20} {1,-300}", ds.Tables[0].Columns[j].ColumnName,ds.Tables[0].Rows[i][j]);
                        }
                    }                     
                }
                
                if(ds.Tables[1].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[1].Rows.Count;i++)
                    {
                        tables1RowsCount++;
                        for(int j=0;j<ds.Tables[1].Columns.Count;j++)
                        {
                            if(!columnTables1List.Contains(ds.Tables[1].Columns[j].ColumnName))
                            {
                                columnTables1List.Add(ds.Tables[1].Columns[j].ColumnName);
                            }
                            Console.WriteLine("{0,-20}{1,-300}", ds.Tables[1].Columns[j].ColumnName, ds.Tables[1].Rows[i][j]);
                        }
                    }
                }
            }

             
            Console.WriteLine("\n\nThere are {0} rows in the table,and every row has {1} columns,and the column name:\n\n",tables0RowsCount,columnTables0List.Count);

            if(columnTables0List!=null && columnTables0List.Any())
            {
                columnTables0List.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }

            Console.WriteLine("\n\n\nThere are {0} row in the table,and every row has {1} columns,and the column name:\n\n", tables1RowsCount, columnTables1List.Count);
            
            if(columnTables1List!=null && columnTables1List.Any())
            {
                columnTables1List.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }

            Console.ReadLine();
        }
    }
}
