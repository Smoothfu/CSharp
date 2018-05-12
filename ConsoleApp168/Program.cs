using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace ConsoleApp168
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the factory for the SQL data provider.
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            Console.WriteLine(sqlFactory.CanCreateDataSourceEnumerator);
            Console.WriteLine(sqlFactory.ToString());
            Console.ReadLine();
        }
    }
}
