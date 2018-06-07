using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp211
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetProductInventory";

                    sqlDataAdapter.SelectCommand = cmd;
                    sqlDataAdapter.Fill(ds);
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                            {
                                Console.Write(ds.Tables[0].Rows[i][j].ToString()+"\t");
                            }
                            Console.WriteLine();
                        }
                    }

                }
            }

            Console.ReadLine();
        }
    }
}
