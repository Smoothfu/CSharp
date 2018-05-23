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
    }
}
