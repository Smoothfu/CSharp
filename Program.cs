using DBDll;
using DBDll.Dll;
using DBDll.Models;
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
            DataTableToTList();
            Console.ReadLine();
        }

        static void DataTableToTList()
        {
            DataTable dt = GetDT();
            List<SODEntity> sodEntitiesList = GetSODEntitiesListFromDT(dt);
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

        static List<SODEntity> GetSODEntitiesListFromDT(DataTable dt)
        {
            List<SODEntity> sodEntitiesList = new List<SODEntity>();
            sodEntitiesList = DataTableConvert.ConvertDataTableToList<SODEntity>(dt);
            return sodEntitiesList;
        }
    }
}
