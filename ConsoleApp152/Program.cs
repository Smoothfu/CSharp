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


            //Assume you really obtained the connectionString value from a*.config file.
            string connectionString = @"Data Source=Fred;Integrated Security=SSPI;Initial Catalog=mydb";
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            //change timeout value.
            connectionStringBuilder.ConnectTimeout = 5;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionStringBuilder.ConnectionString;
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
