using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;


namespace ConsoleApp222
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The main ThreadManagerThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
            ThreadStart ts = new ThreadStart(GetDataBySP);
            Thread thread = new Thread(ts);
            thread.Start();

            Console.ReadLine();
        }

        static void GetDataBySP()
        {
            Console.WriteLine("The thread Id in GetDataBySP() :{0}\n", Thread.CurrentThread.ManagedThreadId);
            string sqlString = ConfigurationManager.AppSettings["connString"].ToString();
            SqlConnection conn = new SqlConnection(sqlString);
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSalesStoreByBID";
                    cmd.Parameters.Add(new SqlParameter("@BID", 302));
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                Console.Write("{0,-2} :{1}\t", ds.Tables[0].Columns[j].ColumnName, ds.Tables[0].Rows[i][j].ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}
