using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp199
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["connString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spGetStoreById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bEID", 292));
                
                cmd.Parameters[0].Value = 292;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);

                if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {                    
                    Console.Write("{0,-10}", ds.Tables[0].Columns[0].ColumnName);
                    Console.Write("{0,-40}", ds.Tables[0].Columns[1].ColumnName);
                    Console.Write("{0,-10}", ds.Tables[0].Columns[2].ColumnName);
                    Console.Write("{0,-40}", ds.Tables[0].Columns[3].ColumnName);
                    Console.Write("{0,-30}", ds.Tables[0].Columns[4].ColumnName);                     

                    Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------------");

                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        Console.Write("{0,-10}", ds.Tables[0].Rows[i][0].ToString());
                        Console.Write("{0,-40}", ds.Tables[0].Rows[i][1].ToString());
                        Console.Write("{0,-10}", ds.Tables[0].Rows[i][2].ToString());
                        Console.Write("{0,-40}", ds.Tables[0].Rows[i][3].ToString());
                        Console.Write("{0,-30}", ds.Tables[0].Rows[i][4].ToString());
                    }
                }
            }

            Console.WriteLine("\n\n\n");

            conn.Close();
            Console.WriteLine("The conn state after Dispose();\n");
            Console.WriteLine(conn.State);
            conn.Dispose();
            Console.WriteLine("The conn state after Dispose();\n");
            Console.WriteLine(conn.State);

            Console.ReadLine();
        }
    }
}
