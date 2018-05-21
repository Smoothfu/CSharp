using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Console;


namespace ConsoleApp172
{
    class Program
    {
        static void Main(string[] args)
        {
            ManipulateDataRowState();
            Console.ReadLine();
        }

        private static void ManipulateDataRowState()
        {
            //Create a temp DataTable for testing.
            var temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            //RowState=Detached.
            var row = temp.NewRow();
            WriteLine($"After calling NewRow():{row.RowState}");

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
    }
}
