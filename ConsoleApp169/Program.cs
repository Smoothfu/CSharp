﻿using System;
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
            WriteLine("*****Fun with Data Readers*****\n");

            //Create and open a connection.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=FRED\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=AutoLot;Connect Timeout=30";
                connection.Open();

                ShowConnectionStatus(connection);

                //Create a SQL command object.
                string selectSQL = "select *from inventory";
                SqlCommand sqlCmd = new SqlCommand(selectSQL, connection);

                //Obtain a data reader via ExecuteReader().
                using (SqlDataReader sqlDataReader = sqlCmd.ExecuteReader())
                {

                    //Loop over the results.
                    while (sqlDataReader.Read())
                    {
                        WriteLine($"-> Make:{sqlDataReader[1]}, PetName:{sqlDataReader[3]},Color:{sqlDataReader[2]}.");
                    }
                }

            }

            ReadLine();
        }


        static void ShowConnectionStatus(SqlConnection connection)
        {
            //Show various stats about current connection object.
            WriteLine("*****Info about your connection******\n");
            WriteLine($"Database location: {connection.DataSource}.\n");
            WriteLine($"Database name :{connection.Database}.\n");
            WriteLine($"Timeout: {connection.ConnectionTimeout}.\n");
            WriteLine($"Connection state: {connection.State}.\n");
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
