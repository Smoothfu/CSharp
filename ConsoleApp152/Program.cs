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
            //Get the factory for the SQL data provider.
           DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            WriteLine(sqlFactory.GetType().Name);
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
