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
                    MessageBox.Show("Connected");
                }
            }
            Console.ReadLine();
        }
    }
}
