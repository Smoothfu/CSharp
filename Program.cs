using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp310
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = "Server=FRED;Database=Adventureworks2017;Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }

                string selectSQL = "select * from sales.Store";
                SqlCommand cmd = new SqlCommand(selectSQL, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                if(ds.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                        {
                            Console.Write(ds.Tables[0].Rows[i][j].ToString()+"\t");
                        }
                        Console.WriteLine();
                    }
                }
                Console.ReadLine();
            }


        }
    }
}
