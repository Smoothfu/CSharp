using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ConsoleApp395.Model;

namespace ConsoleApp395
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream fs=new FileStream("bin5.json",FileMode.Create))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                var sodList = GetSODList();
                binFormatter.Serialize(fs, sodList);
            }
        }

        static List<SalesOrderDetail> GetSODList()
        {
            using(AdventureWorks2017Entities db=new AdventureWorks2017Entities())
            {
                List<SalesOrderDetail> sodList = db.SalesOrderDetail.ToList();
                return sodList;
            }
        }
    }     
}
