using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using static System.Console;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp168
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with Data Provider Factories*****\n");

            //Get Connection string/provider from *.config.
            string dataProvider = ConfigurationManager.AppSettings["oleDbProvider"];
            string connectionString =ConfigurationManager.ConnectionStrings["AutoLolOleDbProvider"].ConnectionString;

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

                WriteLine($"Your connection object is {{0}}\n",connection.GetType().Name);
                connection.ConnectionString = connectionString;
                connection.Open();

                var sqlConn = connection as SqlConnection;
                if (sqlConn != null)
                {
                    //Print out which version of SQL Server is used.
                    WriteLine($"ServerVersion is {sqlConn.ServerVersion}");
                    WriteLine($"AccessToken is {sqlConn.AccessToken}");
                    WriteLine($"ClientConnectionId is {sqlConn.ClientConnectionId}");
                    WriteLine($"ConnectionString is {sqlConn.ConnectionString}");                 
                    WriteLine($"ConnectionTimeout is {sqlConn.ConnectionTimeout}");
                    WriteLine($"Container is {sqlConn.Container}");
                    WriteLine($"Credential is {sqlConn.Credential}");
                    WriteLine($"Database is {sqlConn.Database}");
                    WriteLine($"DataSource is {sqlConn.DataSource}");
                    WriteLine($"FireInfoMessageEventOnUserErrors is {sqlConn.FireInfoMessageEventOnUserErrors}");
                    WriteLine($"GetHashCode() is {sqlConn.GetHashCode()}");
                    WriteLine($"PacketSize is {sqlConn.PacketSize}");
                    WriteLine($"ServerVersion is {sqlConn.ServerVersion}");
                    WriteLine($"Site is {sqlConn.Site}");
                    WriteLine($"State is {sqlConn.State}");
                    WriteLine($"StatisticsEnabled is {sqlConn.StatisticsEnabled}");
                    WriteLine($"WorkstationId is {sqlConn.WorkstationId}");                    
                }               

                //Make command object.
                DbCommand dbCommand = factory.CreateCommand();

                if(dbCommand==null)
                {
                    ShowError("Command");
                    return;
                }

                WriteLine($"Your command object is {{0}}\n",dbCommand.GetType().Name);
                dbCommand.Connection = connection;
                dbCommand.CommandText = "select * from iventory";

                //Print out data with data reader.
                using (DbDataReader dataReader = dbCommand.ExecuteReader())
                {
                    WriteLine($"Your data reader object is  {{0}}\n",dataReader.GetType().Name);

                    WriteLine("\n*****Current Iventory*****\n");
                    while(dataReader.Read())
                    {
                        WriteLine($"-> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
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
