using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp3.DbServiceReference;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            DbServiceReference.DBServiceClient client = new DBServiceClient();
            List<DbClass> serverList = client.GetDbClassList().ToList();
            if(serverList!=null && serverList.Any())
            {
                serverList.ForEach(x =>
                {
                    Console.WriteLine("STableCatalog:{0},STableScheme: {1},STableName: {2},STableType: {3}\n",x.STableCatalog,x.STableScheme,x.STableName,x.STableType);
                });
            }
            Console.ReadLine();
        }
    }
}
