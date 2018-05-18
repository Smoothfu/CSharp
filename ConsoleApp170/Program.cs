using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Console;
using System.Collections;

namespace ConsoleApp170
{
    class Program
    {
        static int tables0RowsCount = 0;
        static int tables1RowsCount = 0;
        static List<string> columnTables0List = new List<string>();
        static List<string> columnTables1List = new List<string>();
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["connString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                WriteLine("*****Fun with DataSets*****\n");

                //Create the DataSet object and add a few properties.
                var carsInventoryDS = new DataSet("Car Inventory");

                carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
                carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
                carsInventoryDS.ExtendedProperties["Company"] = "This is a honored-brand company!";

                FillDataSet(carsInventoryDS);
                ManipulateDataRowState();
                PrintDataSet(carsInventoryDS);

            }

            Console.ReadLine();
        }

        private static void GetTableColumnsName(DataSet ds)
        {
            if(ds!=null && ds.Tables[0].Rows.Count>0)
            {
                for(int i=0;i<ds.Tables[0].Columns.Count;i++)
                {
                    columnTables0List.Add(ds.Tables[0].Columns[i].ColumnName);
                }
            }

            if(columnTables0List!=null && columnTables0List.Any())
            {
                Console.WriteLine("There are {0} columns  in ds.Tables[0],they are:\n",columnTables0List.Count);
                columnTables0List.ForEach(x =>
                {
                    Console.WriteLine(x);
                });

                Console.WriteLine("\n\n\n\n\n");
            }

            if(ds!=null && ds.Tables[1].Rows.Count>0)
            {
                for(int i=0;i<ds.Tables[1].Columns.Count;i++)
                {
                    columnTables1List.Add(ds.Tables[1].Columns[i].ColumnName);
                }
            }

            if(columnTables1List!=null && columnTables1List.Count>0)
            {
                Console.WriteLine("There are {0} columns  in ds.Tables[1],they are:\n",columnTables1List.Count);
                columnTables1List.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }
        }

        static void FillDataSet(DataSet ds)
        {
            //Create data columns that map to the "real" columns in the Inventory table of the AutoLot database.
            var carIDColumn = new DataColumn("CarID", typeof(int))
            {
                Caption = "Car ID",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
                AutoIncrement=true,
                AutoIncrementSeed=1,
                AutoIncrementStep=1
            };

            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));
            var carPetNameColumn = new DataColumn("PetName", typeof(string))
            {
                Caption = "Pet Name"
            };

            //Now add DataColumns to a DataTable.
            var inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new[]
            {
                carIDColumn,carMakeColumn,carColorColumn,carPetNameColumn
            });


            //Now add some rows to the Inventory Table.
            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BENZ Mercedenz";
            carRow["Color"] = "BlackBlack";
            carRow["PetName"] = "BENZAMG65";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            //Column 0 is the AutoIncrement ID field, so start at 1.
            carRow[1] = "Auqi";
            carRow[2] = "Blue";
            carRow[3] = "Auqi Blue";
            inventoryTable.Rows.Add(carRow);

            //Mark the primary key of this table.
            inventoryTable.PrimaryKey = new[] { inventoryTable.Columns[0] };

            ds.Tables.Add(inventoryTable);
        }

        private static void ManipulateDataRowState()
        {
            //Create a temp DataTable for testing.
            var temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            //RowState=Detached.
            var row = temp.NewRow();
            WriteLine($"After calling NewRow(): {row.RowState}");

            //RowState=Added.
            temp.Rows.Add(row);
            WriteLine($"After calling Rows.Add():{row.RowState}");

            //RowState=Added.
            row["TempColumn"] = 10;
            WriteLine($"After first assignment:{row.RowState}");

            //RowState=Unchanged.
            temp.AcceptChanges();
            WriteLine($"After calling AcceptChanges:{row.RowState}");

            //RowState=Modified.
            row["TempColumn"] = 11;
            WriteLine($"After first assignment:{row.RowState}");

            //RowState=Deleted.
            temp.Rows[0].Delete();
            WriteLine($"After calling Delete:{row.RowState}");

        }

        static void PrintDataSet(DataSet ds)
        {
            //Print out the DataSet name and any extended properties.
            WriteLine($"DataSet is named:{ds.DataSetName}");

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
                    WriteLine($"{dt.Columns[curCol].ColumnName}\t");
                }

                WriteLine("\n----------------------------------------------------");

                //Print the DataTable.
                for(var curRow=0;curRow<dt.Rows.Count;curRow++)
                {
                    for(var curCol=0;curCol<dt.Columns.Count;curCol++)
                    {
                        WriteLine($"{dt.Rows[curRow][curCol]}\t");
                    }
                    WriteLine();
                }
            }
        }
    }
}
