using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp312
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {

                //var persons = db.SalesPersons;
                //if(persons!=null && persons.Count()>0)
                //{
                //    foreach(SalesPerson sp in persons)
                //    {
                //        Console.WriteLine(sp.BusinessEntityID);
                //    }
                //}

                var result = (from s in db.SalesPersons
                              from t in db.SalesTerritories
                              where s.TerritoryID == t.TerritoryID
                              select new
                              {
                                  SID = s.BusinessEntityID,
                                  CRC = t.CountryRegionCode
                              }).ToArray();


                List<int> intList = new List<int>();
                if (result != null && result.Count()> 0)
                {
                    Console.WriteLine("Count:"+result.Count());
                    foreach (var r in result)
                    {
                        Console.WriteLine(r.SID + ","+r.CRC+"\n");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
