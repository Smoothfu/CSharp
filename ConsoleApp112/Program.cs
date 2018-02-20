using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp112
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare an instance of Product and display its initial values.
            Product item = new Product("Fasteners", 63434);
            Console.WriteLine("Original values in Main.Name:{0},ID:{1}\n", item.ItemName, item.ItemID);

            //Pass the product instance to ChangeByReference.
            ChangeByReference(ref item);
            Console.WriteLine("Back in Main.Name:{0},ID:{1}\n", item.ItemName, item.ItemID);
            Console.ReadLine();
        }

        static void Add10000000(ref int i)
        {
            i = i + 10000000;
        }

        static void ChangeByReference(ref Product itemRef)
        {
            //Change the address that is stored in the itemRef parameter.
            itemRef = new Product("Stapler", 999999);

            //you can change the value of one of the properties of itemRef.The change happens 
            //to item in Main as well.
            itemRef.ItemID = 234923243;
        }
    }

    class Product
    {
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public Product(string name,int newId)
        {
            ItemName = name;
            ItemID = newId;
        }
    }
}
