using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp208.Model;
using WcfServiceLibrary1;

namespace ConsoleApp208
{
    class Program
    {
        static List<TProd> TProdList = new List<TProd>();
        static void Main(string[] args)
        {
            WcfServiceLibrary1.Service1 client = new WcfServiceLibrary1.Service1();


            var allProdList = client.GetPIList().ToList();
            if (allProdList != null && allProdList.Any())
            {
                allProdList.ForEach(x =>
                {
                    TProdList.Add(new TProd()
                    {
                        TPID = x.PID,
                        TLID = x.LID,
                        TMD = x.MD,
                        TBin = x.Bin,
                        TShelf = x.Shelf,
                        TQuantity = x.Quantity,
                        TRowGuid = x.RowGuid
                    });
                });
            }


            if (TProdList != null && TProdList.Any())
            {
                TProdList.ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }
            Console.ReadLine();
        }
    }

    
}
