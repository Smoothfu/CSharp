using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp198
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
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "spGetStoreByIDName";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bEID", 200));               
                cmd.Parameters.Add(new SqlParameter("@SPID", 200));
                cmd.Parameters.Add(new SqlParameter("@Name", "a"));
                sqlDataAdapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                sqlDataAdapter.Fill(ds);
                if(ds.Tables[0]!=null && ds.Tables[0].Rows.Count>0)
                {

                    Console.WriteLine("There are {0} rows in table!\n", ds.Tables[0].Rows.Count);
                    for(int i=0;i<ds.Tables[0].Columns.Count;i++)
                    {
                        Console.Write("{0,-15}", ds.Tables[0].Columns[i].ColumnName);
                    }

                    Console.WriteLine("\n-------------------------------------------------------------------");

                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                        {
                            Console.Write("{0,-15}", ds.Tables[0].Rows[i][j].ToString());
                        }

                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
