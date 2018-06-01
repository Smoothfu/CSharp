using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp201
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.ConnectionStrings["sqlConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            Console.WriteLine(conn.State);
            Console.WriteLine(1);
            Console.ReadLine();
        }
    }
}
