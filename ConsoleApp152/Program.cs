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

    //A list of possible providers.
    enum DataProviders
    {
        SqlServer,OleDb,Odbc,None
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with Data Readers*****\n");

            //Create and open a connection.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=MyDb";
                connection.Open();

                //Create a SQL command object.
                string sql = "select * from mt";
                SqlCommand cmd = new SqlCommand(sql, connection);

                //Obtain a data reader a la ExecuteReader().
                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    //Loop over the results.
                    while (sqlDataReader.Read())
                    {
                        WriteLine($"->Make:{sqlDataReader["Make"]},PetName:{sqlDataReader["PetName"]},Color:{sqlDataReader["Color"]}.");
                    }
                }
            }
            ReadLine();
        }

        //This method returns a specific connection object based on the value 
        //of a DataProvider enum.
        static IDbConnection GetConnection(DataProviders dataProvider)
        {
            IDbConnection connection = null;

            switch (dataProvider)
            {
                case DataProviders.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProviders.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProviders.Odbc:
                    connection = new OdbcConnection();
                    break;
            }

            return connection;
        }

        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }
    }
}
