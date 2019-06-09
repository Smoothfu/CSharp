using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp356
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string selectSQL = "select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_TYPE='procedure'";
                using (SqlCommand selectCmd = new SqlCommand(selectSQL, conn))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCmd);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        for(int j=0;j<dt.Columns.Count;j++)
                        {
                            Console.Write(dt.Rows[i][j]+"\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
