using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp203
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            Console.WriteLine(conn.State);

            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetCustomer";
                    cmd.Parameters.Add(new SqlParameter("@BEID", 20000));

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);

                    if(ds.Tables!=null && ds.Tables[0]!=null && ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Columns.Count;i++)
                        {
                            Console.Write("{0,-30}", ds.Tables[0].Columns[i].ColumnName);
                        }

                        Console.WriteLine("\n\n");

                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count;j++)
                            {
                                Console.Write("{0,-30}", ds.Tables[0].Rows[i][j].ToString());
                            }

                        }
                    }

                }
            }
            Console.ReadLine();
        }
    }
}
