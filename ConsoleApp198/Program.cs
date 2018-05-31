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

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
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

                    if(ds.Tables[0].Rows.Count>0)
                    {
                        Console.Write("{0,-10}", ds.Tables[0].Columns[0].ColumnName);
                        Console.Write("{0,-40}", ds.Tables[0].Columns[1].ColumnName);
                        Console.Write("{0,-10}", ds.Tables[0].Columns[2].ColumnName);
                        Console.Write("{0,-40}", ds.Tables[0].Columns[3].ColumnName);
                        Console.Write("{0,-40}", ds.Tables[0].Columns[4].ColumnName);
                    }

                    Console.WriteLine("\n\n------------------------------------------------------------------------------------------------------------------------\n\n");

                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        Console.Write("{0,-10}", ds.Tables[0].Rows[i][0].ToString());
                        Console.Write("{0,-40}", ds.Tables[0].Rows[i][1].ToString());
                        Console.Write("{0,-10}", ds.Tables[0].Rows[i][2].ToString());
                        Console.Write("{0,-40}", ds.Tables[0].Rows[i][3].ToString());
                        Console.Write("{0,-40}", ds.Tables[0].Rows[i][4].ToString());                       
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
