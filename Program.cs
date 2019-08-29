using DBDll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp369
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = GetDT();
            PrintDataTable(dt);
            Console.ReadLine();
        }

        static DataTable GetDT()
        {
            DBDataTable obj = new DBDataTable();
            DataTable dt = obj.GetDataTable();
            return dt;
        }

        static void PrintDataTable(DataTable dt)
        {
            if(dt==null || dt.Rows.Count==0)
            {
                return;
            }

            for(int i=0;i<dt.Rows.Count;i++)
            {
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    Console.Write($"{dt.Rows[i][j]?.ToString() + "\t"}");
                }
                Console.WriteLine();
            }
        }
    }
}
