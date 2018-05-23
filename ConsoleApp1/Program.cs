using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2;
using WindowsFormsApp2.AutoLotDataSetTableAdapters;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with strongly typed DataSets*****\n");

            //caller creates the DataSet object.
            var table = new AutoLotDataSet.InventoryDataTable();

            //Inform adapter of the Select command text and connection.
            var adapter = new InventoryTableAdapter();

            //Fill out DataSet with a new table,named Inventory.
            adapter.Fill(table);
            PrintInventory(table);


            Console.WriteLine("\n\n\n\n\nNewly updated\n\n\n\n\n");

            //Add rows,update and reprint
            AddRecords(table, adapter);
            table.Clear();
            adapter.Fill(table);
            PrintInventory(table);
            CallStoredProc();

            Console.ReadLine();
        }

        static void PrintInventory(AutoLotDataSet.InventoryDataTable dt)
        {
            //Print out the column names.
            for(int curCol=0;curCol<dt.Columns.Count;curCol++)
            {
                Write("{0,-30}", dt.Columns[curCol].ColumnName);
            }
            WriteLine("\n----------------------------------------------------------------------------------------------------------------------------------------------");

            //Print the DataTable.
            for(int curRow=0;curRow<dt.Rows.Count;curRow++)
            {
                for(int curCol=0;curCol<dt.Columns.Count;curCol++)
                {
                    Write("{0,-30}", dt.Rows[curRow][curCol]);
                }
                WriteLine();
            }
        }

        public static void AddRecords(AutoLotDataSet.InventoryDataTable table,InventoryTableAdapter adapter)
        {
            try
            {
                //Get a new strongly typed row from the table.
                AutoLotDataSet.InventoryRow newRow = table.NewInventoryRow();

                //Fill row with some sample data.
                newRow.Color = "Purple";
                newRow.Make = "BENZ";
                newRow.PetName = "Saku";


                //Insert the new row.
                table.AddInventoryRow(newRow);

                //Add one more row,using overloaded Add method.
                table.AddInventoryRow("BENZCar", "Black", "BENZ Mercederz");

                //update database.
                adapter.Update(table);
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public static void CallStoredProc()
        {
            try
            {
                var queriesTableAdapter = new WindowsFormsApp2.DataSets.AutoLotDataSetTableAdapters.QueriesTableAdapter();
                Write("Enter ID of car to look up: \n");
                string carID = ReadLine() ?? "0";
                string carName = "";
                queriesTableAdapter.GetPetName(int.Parse(carID), ref carName);
                WriteLine($"CarID {carID} has the name of {carName}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
