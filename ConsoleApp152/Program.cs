using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using static System.Console;
using System.Configuration;
using System.Data.Common;

namespace ConsoleApp152
{ 
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with Data Readers*****\n");
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=Fred;Initial Catalog=mydb;Integrated Security=SSPI;Connect timeout=30";
                con.Open();
                ShowConnectionStatus(con);
            }

            ReadLine();
        }


        static void ShowConnectionStatus(SqlConnection connection)
        {
            //Show various stats about the current connection object.
            WriteLine("*****Info about your connection*****\n");
            WriteLine($"Database location:{connection.DataSource}");
            WriteLine($"Database name:{connection.Database}");
            WriteLine($"Timeout:{connection.ConnectionTimeout}");
            WriteLine($"Connection State:{connection.State}");
        }
        
    }
}
