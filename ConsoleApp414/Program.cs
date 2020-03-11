using System;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp414
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLDemo();
            Console.ReadLine();
        }

        [Log("First")]
        public static void  TestAttribute()
        {
            Console.WriteLine("The first attribute!");
        }

        static void SQLDemo()
        {
            string connString = ConfigurationManager.AppSettings["SqlConnString"].ToString();
            using(SqlConnection conn=new SqlConnection(connString))
            {
                conn.Open();
                string selectSQL = "select * from sales.SalesOrderDetail";
                using(SqlDataAdapter da=new SqlDataAdapter(selectSQL,conn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                    {
                        var columnsCount = ds.Tables[0].Columns.Count;
                        for(int i=0;i<columnsCount;i++)
                        {
                            Console.Write(ds.Tables[0].Columns[i].ColumnName + "\t");
                        }
                    }
                }
            }
        }
    }

    public class LogAttribute : Attribute
    {
        public string Msg { get; set; }
        public LogAttribute(string msgValue)
        {
            Msg = msgValue;
        }
    }

}
