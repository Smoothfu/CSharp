using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp312
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = Power(2, 10).ToList();
            if(intList!=null && intList.Count>0)
            {
                foreach(int i in intList)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }

        static void EnumerableToArray()
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
                if (result != null && result.Count() > 0)
                {
                    Console.WriteLine("Count:" + result.Count());
                    foreach (var r in result)
                    {
                        Console.WriteLine(r.SID + "," + r.CRC + "\n");
                    }
                }
            }
            
        }

        static IEnumerable<int> Power(int num,int exponent)
        {
            int result = 1;
            for(int i=0;i<exponent;i++)
            {
                result = result * num;
                yield return result;
            }
        }
    }

    public static class GalaxyClass
    {
        public static void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
        }

        public class Galaxies
        {

            public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }

        }

        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }
    }
}
