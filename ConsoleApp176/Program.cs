using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using static System.Console;
using System.Data.SqlClient;
using System.Collections;

namespace ConsoleApp176
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with Data Adapters*****\n");

            //Hard-coded connection string.
            string connectionString = @"Server=FRED\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=SSPI;";

            //Caller creates the DataSet object.
            DataSet ds = new DataSet("AutoLot");

            string selectSQL = "select * from Inventory;select* from Customers;select* from Orders";
            //Inform adapter of the Select command text and connection.
            SqlDataAdapter adapter = new SqlDataAdapter(selectSQL, connectionString);

           


            //Now map DB column names to user-friendly names.
            DataTableMapping tableMapping = adapter.TableMappings.Add("Inventory", "Currnt Inventory");
            tableMapping.ColumnMappings.Add("CarId", "Car Id");
            tableMapping.ColumnMappings.Add("PetName", "Name of Car");
            //adapter.Fill(ds, "Inventory");

            //Fill our dataset with a new table named Inventory.
            adapter.Fill(ds, "Inventory");

            PrintDataSet(ds);
            Console.ReadLine();
        }

        static void PrintDataSet(DataSet ds)
        {
            //Print out any name and extended properties.
            WriteLine($"DataSet is named:{ds.DataSetName}");

            foreach(DictionaryEntry de in ds.ExtendedProperties)
            {
                WriteLine($"Key={de.Key},Value={de.Value}");
            }

            WriteLine();

            foreach(DataTable dt in ds.Tables)
            {
                WriteLine($"=>{dt.TableName} Table:");

                //Print out the column names.
                for(int curCol=0;curCol<dt.Columns.Count;curCol++)
                {
                    Write("{0,-30}",dt.Columns[curCol].ColumnName);
                }

                WriteLine("\n------------------------------------------------------------------------");

                //Print the DataTable.
                for(int curRow=0;curRow<dt.Rows.Count;curRow++)
                {
                    for(int curCol=0;curCol<dt.Columns.Count;curCol++)
                    {
                        Write("{0,-30}",dt.Rows[curRow][curCol].ToString().Trim());
                    }
                    WriteLine();
                }

                Console.WriteLine("\n\n\n\n\n");
            }
        }
    }
}
