using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using static System.Console;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace ConsoleApp168
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with Data Readers*****\n");

            //Create a connection string via the builder object.
            var cnStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "AutoLol",
                DataSource= @"FRED\SQLEXPRESS",
                ConnectTimeout=30,
                IntegratedSecurity=true
            };

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnStringBuilder.ConnectionString;
                connection.Open();
                ShowConnectionStatus(connection);
            }

            ReadLine();
        }

        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }

        static void ShowConnectionStatus(SqlConnection connection)
        {
            //Show various stats about current connection object.
            WriteLine($"*****Info about your connection*****\n");
            WriteLine($"Database location:{connection.DataSource} \n");
            WriteLine($"Database name: {connection.Database} \n");
            WriteLine($"Timeout: {connection.ConnectionTimeout} \n");
            WriteLine($"Connection State: {connection.State} \n");
        }
    }
}
