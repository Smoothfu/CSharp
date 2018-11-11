using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WcfServiceLibrary1;
 

namespace ConsoleApp280
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ServiceReference1.DateServiceClient client=new ServiceReference1.DateServiceClient()


            Console.ReadLine();
        }

        static void RetrieveFromDB()
        {
            string connString = ConfigurationManager.AppSettings["conString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string selectSQL = "select distinct sod.ProductID from " +
                    "sales.SalesOrderHeader soh join sales.SalesOrderDetail " +
                    "sod on soh.SalesOrderID = sod.SalesOrderID where " +
                    "OrderDate = (select min(OrderDate) from sales.SalesOrderHeader)";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = selectSQL;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                Console.Write(ds.Tables[0].Rows[i][j].ToString());
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }

        }
    }
}
