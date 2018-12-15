using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp311
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                var stores = db.Stores;
                if(stores!=null && stores.Count() > 0)
                {
                    foreach (Store s in stores)
                    {
                        Console.WriteLine(s.BusinessEntityID);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
