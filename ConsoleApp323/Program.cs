using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp323
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlDataAdapterDB();
            Console.ReadLine();
        }

        static void SqlDataAdapterDB()
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            string selectSQL= @"select SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber,OrderQty,
            ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,rowguid,ModifiedDate 
            from sales.SalesOrderDetail";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand selectCmd = new SqlCommand(selectSQL, conn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            string rowMsg = $"{ds.Tables[0].Rows[i][0],-10}{ds.Tables[0].Rows[i][1],-10}" +
                                 $"{ds.Tables[0].Rows[i][2],-15}{ds.Tables[0].Rows[i][3],-5}" +
                                 $"{ds.Tables[0].Rows[i][4],-5}{ds.Tables[0].Rows[i][5],-5}" +
                                $"{ds.Tables[0].Rows[i][6],-10}{ds.Tables[0].Rows[i][7],-10}" +
                                $"{ds.Tables[0].Rows[i][8],-15}{ds.Tables[0].Rows[i][9],-45}" +
                                $"{ds.Tables[0].Rows[i][10],-30}";
                            Console.WriteLine(rowMsg); 
                        }
                    }
                }
            }

        }
    }
}
