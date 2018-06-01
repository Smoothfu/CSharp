using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp199
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            Console.WriteLine("Now the SqlConnection's state is {0}.\n\n", conn.State);

            if (conn.State == ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRetriveStores";
                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    sda.SelectCommand = cmd;
                    sda.Fill(ds);

                    if (ds.Tables != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        Console.WriteLine("\nThere are {0} rows data totally!\n", ds.Tables[0].Rows.Count);
                        Console.Write("{0,-10}", ds.Tables[0].Columns[0].ColumnName);
                        Console.Write("{0,-40}", ds.Tables[0].Columns[1].ColumnName);
                        Console.Write("{0,-10}", ds.Tables[0].Columns[2].ColumnName);
                        Console.Write("{0,-40}", ds.Tables[0].Columns[3].ColumnName);
                        Console.Write("{0,-30}", ds.Tables[0].Columns[4].ColumnName);

                        Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------------\n");

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Console.Write("{0,-10}", ds.Tables[0].Rows[i][0].ToString());
                            Console.Write("{0,-40}", ds.Tables[0].Rows[i][1].ToString());
                            Console.Write("{0,-10}", ds.Tables[0].Rows[i][2].ToString());
                            Console.Write("{0,-40}", ds.Tables[0].Rows[i][3].ToString());
                            Console.Write("{0,-30}\n", ds.Tables[0].Rows[i][4].ToString());
                        }
                    }
                }
            }

            conn.Close();
            Console.WriteLine("\nAfter conn.Close(),the conn.State is:{0}\n", conn.State);

            conn.Dispose();
            Console.WriteLine("\nAfter conn.Dispose(),the conn.State is:{0}\n", conn.State);
            Console.ReadLine();
        }
    }
}
