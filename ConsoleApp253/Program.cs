using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ConsoleApp253
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["conString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string selectSQL = "select * from INFORMATION_SCHEMA.TABLES where table_type='BASE TABLE'";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = selectSQL;
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                        sqlDataAdapter.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        sqlDataAdapter.Fill(ds);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                            {
                                for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                                {
                                    Console.Write("{0:30}\t", ds.Tables[0].Rows[i][j].ToString());
                                }
                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
