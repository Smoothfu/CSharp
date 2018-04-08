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
            Console.WriteLine("*****Very Simple Connection Factory*****\n");

            //Read the provider key.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            //Transform string to enum.
            DataProviders dataProvider = DataProviders.None;

            if(Enum.IsDefined(typeof(DataProviders),dataProviderString))
            {
                dataProvider = (DataProviders)Enum.Parse(typeof(DataProviders), dataProviderString);
            }
            else
            {
                WriteLine("Sorry,no provider exist!");
                ReadLine();
                return;
            }

            //Get a specific connection.
            IDbConnection myConnection = GetConnection(dataProvider);
            WriteLine($"Your connection is {myConnection?.GetType().Name ?? "unrecognized type"}");

            //Open,use and close connection... 
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
    }
}
