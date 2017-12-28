using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp66
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make an anonymous type that is composed of another.
            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Black", Make = "Mercedes Benz", CurrentSpeed = 55 },
                Price = 34.000
            };


            ReflectOverAnonymousType(purchaseItem);
            Console.ReadLine();
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of :{0}\n", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}\n", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString()=={0}\n", obj.ToString());
            Console.WriteLine("obj.GetHashCode()=={0}\n", obj.GetHashCode());
            Console.WriteLine();
        }
    }
}
