using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace ConsoleApp167
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
            WriteLine("*****Very Simple Connection Factory*****\n");

            //Read the provider key.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            //Transfrom string to enum.

            DataProvider dataProvider = DataProvider.None;

            if(Enum.IsDefined(typeof(DataProvider),dataProviderString))
            {
                dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            }

            else
            {
                WriteLine("Sorry,no providers exist!");
                ReadLine();
                return;
            }
            //Get a specific connection.
            IDbConnection conn = GetConnection(DataProvider.SqlServer);
            WriteLine($"Your connection is a {conn.GetType().Name}");

            //Open use and close connection.
            ReadLine();
        }

        //This method returns a specific connection object based on value of a DataProvider enum.
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection conn = null;
            switch(dataProvider)
            {
                case DataProvider.SqlServer:
                    conn = new SqlConnection();
                    break;

                case DataProvider.OleDb:
                    conn = new OleDbConnection();
                    break;

                case DataProvider.Odbc:
                    conn = new OdbcConnection();
                    break;
            }
            return conn;
        }
    }
}
