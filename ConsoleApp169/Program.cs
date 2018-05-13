using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;
using System.Data.Common;

namespace ConsoleApp169
{
    //A list of possible providers.
    enum DataProvider
    {
        SqlServer,OleDb,Odbc,None
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with Data Provider Factories*****\n");

            //Get connection string/provider from *.config.
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            //Get the factory provider.
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            //Now get the connection object.
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Connection");
                    return;
                }

                WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                //Make command object.
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }

                WriteLine($"Your command object is a :{command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "select * from inventory";

                //Print out data with data reader.
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader object is a:{dataReader.GetType().Name}");
                    while (dataReader.Read())
                    {
                        WriteLine($"->Car #{dataReader[1]} is a {dataReader[2]}.");
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

        //This method returns a specific connection object based on the value of a DataProvider enum.
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch(dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;

                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;

                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
            }
            return connection;
        }
    }
}
