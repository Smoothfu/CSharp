using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary12;
using ConsoleApp275.MathServiceReference;


namespace ConsoleApp275
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (MathServiceClient mathClient = new MathServiceClient())
                {
                    List<DBTables> resultList = mathClient.GetDBColumnString().ToList();
                    if (resultList != null && resultList.Any())
                    {
                        resultList.ForEach(x =>
                        {
                            Console.WriteLine("STABLECATALOG:{0,-20} STABLESCHEMA:{1,-20} STABLENAME:{2,-50} STABLETYPE:{3,-30}\n", x.STABLECATALOG, x.STABLESCHEMA, x.STABLENAME, x.STABLETYPE);
                        });
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
               
            Console.ReadLine();                
        }
    }

    class CTableString
    {
        public string CTableCatalog { get; set; }
        public string CTableScheme { get; set; }
        public string CTableName { get; set; }
        public string CTableType { get; set; }
    }
}
