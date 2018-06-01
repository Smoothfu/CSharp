using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp201
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.ConnectionStrings["sqlConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            Console.WriteLine(conn.State);

            
            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetProductByPIDRange";
                    cmd.Parameters.Add(new SqlParameter("@MinPID", 1));
                    cmd.Parameters.Add(new SqlParameter("@MaxPID", 10));
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    sqlDataAdapter.SelectCommand = cmd;
                    sqlDataAdapter.Fill(ds);

                    if(ds!=null && ds.Tables!=null && ds.Tables[0].Rows.Count>0)
                    {
                        //Column names
                        for(int i=0;i<ds.Tables[0].Columns.Count;i++)
                        {
                            Console.Write("{0,-30}", ds.Tables[0].Columns[i].ColumnName);
                        }

                        Console.WriteLine();
                        
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                            {
                                Console.Write("{0,-30}", ds.Tables[0].Rows[i][j].ToString());
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
