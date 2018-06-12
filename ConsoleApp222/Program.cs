using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ConsoleApp222
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlString = ConfigurationManager.AppSettings["connString"].ToString();
            SqlConnection conn = new SqlConnection(sqlString);
            conn.Open();
            

            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSalesStoreByBID";
                    cmd.Parameters.Add(new SqlParameter("@BID", 300));
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if(ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                            {
                                Console.Write("{0,-5} {1}\t",ds.Tables[0].Columns[j].ColumnName,ds.Tables[0].Rows[i][j].ToString());
                            }
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
