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
    public delegate void AddDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The main ThreadManagerThreadId:{0}", Thread.CurrentThread.ManagedThreadId);

            AddDel addDel = new AddDel(AddMethod);
            addDel(10000, 1000000000);

            Console.ReadLine();
        }

        static void DescPerson(object obj)
        {
            var objPerson = obj as Person;
            if(objPerson!=null)
            {
                Console.WriteLine(objPerson.ToString());
            }
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("The ThreadId in AddMethod is {0}\n",Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
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

    public class Person
    {
        public int PId { get; set; }
        public string PName { get; set; }

        public Person(int pId,string pName)
        {
            PId = pId;
            PName = pName;
        }

        public override string ToString()
        {
            return string.Format("PId:{0},PName:{1}\n", PId, PName);
        }
    }
}
