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


            //Assume you really obtained the connectionString value from a *.config file.
            string connectionString = @"Data Source=FRED\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=AutoLol";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //Create command object via ctor args.
            string sql = "select * from iventory";
            SqlCommand sqlCmd = new SqlCommand(sql, conn);

            //Create another command object via properties.
            SqlCommand testCmd = new SqlCommand();
            testCmd.Connection = conn;
            testCmd.CommandText = sql;

            //Obtain a data reader via ExecuteReader()
            using (SqlDataReader myDataReader = sqlCmd.ExecuteReader())
            {
                //Loop over the results
                while (myDataReader.Read())
                {
                    WriteLine($"->Make:{ myDataReader["Make"]}, PetName:{myDataReader["PetName"]}, Color:{myDataReader["Color"]}.");
                }
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
