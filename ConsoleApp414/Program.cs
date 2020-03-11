using System;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ConsoleApp414
{
    class Program
    {
        static void Main(string[] args)
        {
            AttDemo();
            Console.ReadLine();
        }

        private static void AttDemo()
        {
            var mis = typeof(Program).GetMethods();
            if(mis!=null && mis.Any())
            {
                foreach(var mi in mis)
                {
                    var ta = (TestAttribute)Attribute.GetCustomAttribute(mi, typeof(TestAttribute));
                    if(ta!=null)
                    {
                        Console.WriteLine($"{ta.Repetitions},{ta.Msg}");
                    }
                }
            }
            
        }

        [Test(1,"First")]
        public void FirstMethod()
        {
            Console.WriteLine("The first attribute!");
        }

        [Test(2,"Second")]
        public void SecondMethod()
        {
            Console.WriteLine("The second method!");
        }

        [Test(3,"Third")]
        public void ThirdMethod()
        {
            Console.WriteLine("The third method!");
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

    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
        public int Repetitions { get; set; }
        public string Msg { get; set; }

        public TestAttribute(int rep,string msgValue) 
        {
            Repetitions = rep;
            Msg = msgValue;
        }
    }

}
