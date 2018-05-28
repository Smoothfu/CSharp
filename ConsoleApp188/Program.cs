using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;

namespace ConsoleApp188
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Inventory> inventoryList = new List<Inventory>();
            WcfServiceLibrary1.Service1 obj = new Service1();
            inventoryList=obj.GetAllInventory();
            if(inventoryList!=null && inventoryList.Any())
            {
                inventoryList.ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }

            Console.ReadLine();
        }
    }
}
