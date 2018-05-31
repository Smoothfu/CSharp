using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp197
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlConnString = ConfigurationManager.AppSettings["sqlConnString"].ToString();
            using (SqlConnection conn = new SqlConnection(sqlConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                try
                {
                    cmd = new SqlCommand("spGetCustomerInfo", conn);
                    cmd.Parameters.Add(new SqlParameter("@MinCID", SqlDbType.Int, 0));
                    cmd.Parameters[0].Value = 0;
                    cmd.Parameters.Add(new SqlParameter("@MaxCID", SqlDbType.Int, 10));
                    cmd.Parameters[1].Value = 10;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            Console.Write("{0,-20}", dt.Columns[i].ColumnName);
                        }

                        Console.WriteLine("\n-----------------------------------------------------------------------------");

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                Console.Write("{0,-20}", dt.Rows[i][j].ToString());
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            Console.ReadLine();
        }
    }
}
