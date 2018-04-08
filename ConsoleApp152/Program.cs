using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

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

            //Get a specific connection.
            IDbConnection myConnection = GetConnection(DataProviders.SqlServer);

            Console.WriteLine($"Your connection is a {myConnection.GetType().Name}");

            //Open,use and close connection.
            Console.ReadLine();
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
