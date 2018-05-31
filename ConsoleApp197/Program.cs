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
            SqlConnection conn = new SqlConnection(sqlConnString);
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                string selectSQL = "select * from AdventureWorks2014.sales.vStoreWithContacts;select * from AdventureWorks2014.Sales.Store";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSQL, conn);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                if (ds.Tables[0]!=null)
                {
                    for(int i=0;i<ds.Tables.Count;i++)
                    {
                        for(int j=0;j<ds.Tables[i].Rows.Count;j++)
                        {
                            for(int k=0;k<ds.Tables[i].Columns.Count;k++)
                            {
                                Console.Write("{0,-20}", ds.Tables[i].Rows[j][k].ToString());
                            }
                        }
                    }

                    Console.WriteLine("\n\n\n\n\n");
                }
            }

            conn.Close();
            Console.WriteLine(conn.State);
            Console.ReadLine();
        }
    }
}
