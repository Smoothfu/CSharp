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
            //Get the factory for the SQL data provider.
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            Console.WriteLine(sqlFactory.CanCreateDataSourceEnumerator);
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
