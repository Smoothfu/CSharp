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
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetStoreByBusinessEntityID";

                    SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@bEntityID",SqlDbType.Int,10) };
                    parms[0].Value = 292;
                    cmd.Parameters.Add(parms[0]);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();

                }
            }


                Console.ReadLine();
        }
    }
}
