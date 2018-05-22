using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using static System.Console;
using System.Collections;

namespace ConsoleApp174
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["conString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            if(!(conn.State==ConnectionState.Open))
            {
                return;
            }

            string selectSQL = "select * from AdventureWorks2014.Person.vStateProvinceCountryRegion;select * from AdventureWorks2014.Sales.vStoreWithContacts;select * from AdventureWorks2014.Person.vAdditionalContactInfo";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSQL, conn);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);

            if(ds.Tables[0].Rows.Count>0)
            {
                PrintDataSet(ds);
            }

            Console.ReadLine();
        }

        static void PrintDataSet(DataSet ds)
        {
            //Print out the DataSet name and any extended properties.
            WriteLine($"DataSet is named: {ds.DataSetName}");
            
            foreach(DictionaryEntry de in ds.ExtendedProperties)
            {
                WriteLine($"Key={de.Key},Value={de.Value}");
            }

            WriteLine();

            //Print out each table using rows and columns.

            foreach(DataTable dt in ds.Tables)
            {
                WriteLine($"=>{dt.TableName} Table:");

                //Print out the column names.
                for(var curCol=0;curCol<dt.Columns.Count;curCol++)
                {
                    Write("{0,-50}",$"{dt.Columns[curCol].ColumnName}\t");
                }

                WriteLine("\n-----------------------------------------------");

                ////Print the DataTable.
                //for(var curRow=0;curRow<dt.Rows.Count;curRow++)
                //{
                //    for(var curCol = 0; curCol < dt.Columns.Count; curCol++)
                //    {
                //        Write("{0,-20}",$"{dt.Rows[curRow][curCol]}\t");
                //    }
                //    WriteLine();
                //}

                PrintTable(dt);

                Console.WriteLine("\n\n\n\n\n\n\n");
            }
        }

        static void PrintTable(DataTable dt)
        {
            //Get the DataTableReader type.
            DataTableReader dtReader = dt.CreateDataReader();

            //The DataTableReader works just like the DataReader.
            while(dtReader.Read())
            {
                for(int i=0;i<dtReader.FieldCount;i++)
                {
                    Write("{0,-50}", $"{dtReader.GetValue(i).ToString().Trim()}\t");
                }
                WriteLine();
            }

            dtReader.Close();
        }

    }
}
