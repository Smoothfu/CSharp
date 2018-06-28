using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp236
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            string conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetAllStores";
                     
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            for(int j=0;j<ds.Tables[0].Columns.Count;j++)
                            {
                                Console.Write(ds.Tables[0].Rows[i][j].ToString() + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
             
            Console.ReadLine();
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("It's age is {0},and time is {1}\n", e.Age, e.Dt);
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

        public void JudgePersonAdult(Person p)
        {
            if(p.Age>18)
            {
                OnJudgeAdultEvent();
            }
        }

        protected void OnJudgeAdultEvent()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age, DateTime.Now));
            }
        }
    }

    public class PersonEventArgs:EventArgs
    {
        public int Age { get; set; }
        public DateTime Dt { get; set; }

        public PersonEventArgs(int age,DateTime dt)
        {
            Age = age;
            Dt = dt;
        }
    }
}
