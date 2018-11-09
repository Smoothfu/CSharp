using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Threading;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp279
{
    class Program
    {
        delegate void AddDel(int x, int y);
        delegate void StringDel(string str);
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["conString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }

                string select = "select top(20) * from INFORMATION_SCHEMA.tables " +
                    "where TABLE_NAME not in(select top(10) TABLE_NAME from INFORMATION_SCHEMA.TABLES " +
                    "order by TABLE_NAME) order by TABLE_NAME";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = select;

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);

                    if(ds.Tables[0]!=null && ds.Tables[0].Rows.Count>0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                            {
                                Console.Write(ds.Tables[0].Rows[i][j]+"\t");
                            }
                            Console.WriteLine();
                        }
                    }

                }

            }


                Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
