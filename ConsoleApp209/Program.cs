using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace ConsoleApp209
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Main Thread ManagedThreadId:{0}\n", Thread.CurrentThread.ManagedThreadId);

            Person p = new Person(1, "Floomberg");
            ParameterizedThreadStart pts = new ParameterizedThreadStart(GetPerson);
            Thread newThread = new Thread(pts);
            newThread.Start(p);
            Console.WriteLine("Priority:{0}\n", newThread.Priority);
            Console.WriteLine("ManagerId:{0}\n", newThread.ManagedThreadId);
            Console.WriteLine("ThreadState:{0}\n", newThread.ThreadState);
            Console.ReadLine();           
        }
        static void GetDataFromDB()
        {
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetProductInventory";
                    sqlDataAdapter.SelectCommand = cmd;
                    sqlDataAdapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                Console.Write("{0,-10} {1,-30}", ds.Tables[0].Columns[j].ColumnName, ds.Tables[0].Rows[i][j].ToString() + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        static void GetPerson(object obj)
        {
            var objPerson = obj as Person;
            if(objPerson!=null)
            {
                Console.WriteLine(objPerson.ToString());
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
