using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp314
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                var stores = db.Stores;
                if(stores!=null && stores.Any())
                {
                    foreach(var s in stores)
                    {
                        Console.WriteLine($"{s.BusinessEntityID},{s.ModifiedDate},{s.Name},{s.rowguid}");
                    }
                }

            }
            Console.ReadLine();
        }
    }
}
