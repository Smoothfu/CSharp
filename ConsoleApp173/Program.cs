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

namespace ConsoleApp173
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

            string selectSQL = "select * from Person.vStateProvinceCountryRegion";
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
            WriteLine($"DataSet is named:{ds.DataSetName}");
            foreach(DictionaryEntry de in ds.ExtendedProperties)
            {
                WriteLine($"Key={de.Key},Value={de.Value}");
            }

            WriteLine("\n\n\n"); 

            //Print out each table using rows and columns.
            foreach(DataTable dt in ds.Tables)
            {
                WriteLine($"=>{dt.TableName} Table:");

                //Print out the column names.
                for(var curCol=0;curCol<dt.Columns.Count;curCol++)
                {
                    Write($"{dt.Columns[curCol].ColumnName}\t");
                }
                WriteLine("\n---------------------------------------------\n");

                //Print the DataTable.
                for(var curRow=0;curRow<dt.Rows.Count;curRow++)
                {
                    for (var curCol = 0; curCol < dt.Columns.Count;curCol++)
                    {
                        Write($"{dt.Rows[curRow][curCol]}\t");
                    }
                    WriteLine();
                }
            }
        }
    }
}
