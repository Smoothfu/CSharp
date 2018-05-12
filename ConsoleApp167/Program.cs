using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace ConsoleApp167
{

    //A list of possible providers.
    enum DataProvider
    {
        SqlServer,OleDb,Odbc,None
    }
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"server=FRED\SQLEXPRESS;database=AutoLol;integrated security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                string sql = "select orderid,custid,carid from orders";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if(ds.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        Console.WriteLine("orderId:{0},CustId:{1},CarId:{2}\n", ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2]);
                    }
                }
            }

            ReadLine();
        }

        //This method returns a specific connection object based on value of a DataProvider enum.
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection conn = null;
            switch(dataProvider)
            {
                case DataProvider.SqlServer:
                    conn = new SqlConnection();
                    break;

                case DataProvider.OleDb:
                    conn = new OleDbConnection();
                    break;

                case DataProvider.Odbc:
                    conn = new OdbcConnection();
                    break;
            }
            return conn;
        }
    }
}
