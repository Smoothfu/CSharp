using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ConsoleApp1
{
    class Program
    {
        static  List<TStore> tStoreList = new List<TStore>();
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            var serviceList = client.GetAllStoresFromvStoreWithContacts().ToList();

            if(serviceList!=null && serviceList.Any())
            {
                serviceList.ForEach(x =>
                {
                    tStoreList.Add(new TStore()
                    {
                        TBID = x.BID,
                        TName = x.Name,
                        TCT = x.CT,
                        TTitle=x.Title,
                        TFN=x.FN,
                        TMN=x.MN,
                        TLN=x.LN
                    });
                });
            }

            if(tStoreList!=null && tStoreList.Any())
            {
                Console.WriteLine("So far there are {0} rows data from the server\n\n\n", tStoreList.Count);
                tStoreList.ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }
             
            Console.ReadLine();
        }
    }
}
