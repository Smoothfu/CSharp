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
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSql, conn);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);

                if(ds.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        rowsCount++;
                        for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                        {
                            if(!columnList.Contains(ds.Tables[0].Columns[j].ColumnName))
                            {
                                columnList.Add(ds.Tables[0].Columns[j].ColumnName);
                            }
                            
                            Console.WriteLine("{0,-20} {1,-300}", ds.Tables[0].Columns[j].ColumnName,ds.Tables[0].Rows[i][j]);
                        }
                    }                     
                }                
            }

             
            Console.WriteLine("\n\nThere are {0} rows in the table,and every row has {1} columns,and the column name:\n\n",rowsCount,columnList.Count);

            if(columnList!=null && columnList.Any())
            {
                columnList.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }
            
            Console.ReadLine();
        }
    }
}
