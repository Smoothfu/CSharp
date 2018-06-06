using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace ConsoleApp209
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(GetDataFromDB);
            Thread newThread = new Thread(ts);
            newThread.Start();
            Console.ReadLine();           
        }
        static void GetDataFromDB()
        {
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetProductInventory";
                    sqlDataAdapter.SelectCommand = cmd;
                    sqlDataAdapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                Console.Write("{0,-10} {1,-30}", ds.Tables[0].Columns[j].ColumnName, ds.Tables[0].Rows[i][j].ToString() + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
