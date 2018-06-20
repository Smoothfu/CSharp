using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp229
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("The ManagedThreadId in Main method is {0}\n", Thread.CurrentThread.ManagedThreadId);
            string conString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection conn = new SqlConnection(conString);
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetProductModelByPMID";
                cmd.Parameters.Add(new SqlParameter("@PMID", 1));
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if(ds.Tables[0].Rows.Count>0)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        Console.Write("{0,-30}", ds.Tables[0].Columns[j].ColumnName);
                    }
                    Console.WriteLine();
                    for (int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            Console.Write("{0,-30}", ds.Tables[0].Rows[i][j].ToString());
                        }                           
                    }
                }
            }
                Console.ReadLine();
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("This is an adult and its age is {0},now is {1}\n",e.PAge,e.Dt.ToString("yyyyMMMdddHHmmssfff"));
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("The ManagerThreadId in Add method is {0}\n", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }

    public class Person
    {
        public event JudgeAdultHandler JudgeAdultEvent;
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        protected void RaiseJudgeAdultEvent()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age,DateTime.Now));
            }
        }

        internal void JudgePerson(object obj)
        {
            var p = obj as Person;
            if (p != null)
            {
                if(p.Age>18)
                {
                    RaiseJudgeAdultEvent();
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Age:{0},Name:{1}\n", Age, Name);
        }
    }

    public class PersonEventArgs:EventArgs
    {
        public int PAge { get; set; }
        public DateTime Dt { get; set; }
        public PersonEventArgs(int pAge,DateTime dt)
        {
            PAge = pAge;
            Dt = dt;
        }        
    }
}
