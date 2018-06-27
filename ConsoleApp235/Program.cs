using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp235
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            string connString = @"Server=192.168.92.1\SQLEXPRESS,1433;Database=AdventureWorks2014;Integrated Security=SSPI;Connect Timeout=30;";
            SqlConnection conn = new SqlConnection(connString);
           
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetAllTables";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);

                    if(ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                            {
                                string result = string.Format("{0,-40}", ds.Tables[0].Rows[i][j].ToString());
                                Console.Write(result);
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
