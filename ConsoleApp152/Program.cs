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
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //Create command object via ctor args.
            string sql = "select * from mt";
            SqlCommand cmd = new SqlCommand(sql,conn);

            //Create another command object via properties.
            cmd.ExecuteNonQuery();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while(sdr.Read())
                {
                    Console.WriteLine("CarId:{0},Make:{1}, Color:{2},PetName:{3}\n", sdr[0], sdr[1],sdr[2],sdr[3]);
                }
            }


            Console.ReadLine();


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
