using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using static System.Console;
using System.Data.Common;

namespace ConsoleApp175
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with Data Adapters*****\n");

            //Hard-coded connection string;
            string connString = @"Data Source=FRED\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=SSPI";

            //Caller creates the DataSet object.
            DataSet ds = new DataSet("AutoLot");

            //Inform adapter of the select command text and connection.
            SqlDataAdapter adapter = new SqlDataAdapter("select * from inventory", connString);

            //Fill our DataSet with a new table,named Inventory.
            


            //Now map DB column names to user-friendly names.
            DataTableMapping tableMapping = adapter.TableMappings.Add("Invetory", "Current Inventory");
            tableMapping.ColumnMappings.Add("CarId", "Car Id");
            tableMapping.ColumnMappings.Add("PetName", "Name of Car");
            adapter.Fill(ds, "Inventory");



            //Display contens of DataSet.
            PrintDataSet(ds);
            ReadLine();

        }

        static void PrintDataSet(DataSet ds)
        {
            //Display column names.

            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                Write("{0,-30}", ds.Tables[0].Columns[i].ColumnName);
            }
            WriteLine("\n-----------------------------------------------------------------");
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    Write("{0,-30}", ds.Tables[0].Rows[i][j]);
                }
            }
        }
    }
}
