using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp347
{
    class Program
    {
        static void Main(string[] args)
        {
           Task task=Task.Run(() =>
            {
                ADO();
            });
            Console.WriteLine($"task.Status:{task.Status}");
            task.Wait();
            Console.WriteLine($"task.Status:{task.Status}");
            Console.ReadLine();
        }

        static void ADO()
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }

                string selectSQL = $"select SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber," +
                    "OrderQty,ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,rowguid," +
                    "ModifiedDate from sales.SalesOrderDetail";
                using (SqlCommand cmd = new SqlCommand(selectSQL, conn))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while(dataReader.Read())
                    {
                        Console.WriteLine(dataReader[0] + "," + dataReader[1] + "," + dataReader[2] + "," + dataReader[3] + "," +
                            dataReader[4] + "," + dataReader[5] + "," + dataReader[6] + "," + dataReader[7] + "," + dataReader[8] + "," +
                            dataReader[9] + "," + dataReader[10]);
                    }
                }
            }
        }
    }
}
