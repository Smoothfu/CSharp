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

            //Create and open a connection.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=FRED\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=AutoLol";
                connection.Open();

                //Create a SQL command object.
                string sql = "Select * from iventory";
                SqlCommand sqlCmd = new SqlCommand(sql, connection);

                //Obtain a data reader a ExecuteReader();
                using (SqlDataReader sqlDataReader = sqlCmd.ExecuteReader())
                {
                    //Loop over the results.
                    while(sqlDataReader.Read())
                    {
                        WriteLine($"->Make: {sqlDataReader["Make"]},PetName:{sqlDataReader["PetName"]},Color:{sqlDataReader["Color"]}.");
                    }
                }
            }
                ReadLine();
        }

        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }
    }
}
