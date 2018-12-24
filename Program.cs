using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp313
{
    class Program
    {
        public delegate void CallHandler(string msg);
        public event CallHandler CallEvent;
        public delegate void MathDel(int x, int y);
        public event MathDel MathEvent;
        public event EventHandler MyOwnEvent;

        static void Main(string[] args)
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                List<Store> storesList = db.Stores.ToList();
                if (storesList != null && storesList.Any())
                {
                    foreach (Store s in storesList)
                    {
                        Console.WriteLine($"{s.BusinessEntityID},{s.ModifiedDate},{s.Name}");
                    }
                }
            }
            Console.ReadLine();
        }

        private static void P_MathEvent(int x, int y)
        {
            Console.WriteLine($"This is multiply {x}*{y}={x * y}");
        }

        public void OnMathEvent(int x, int y)
        {
            if(MathEvent!=null)
            {
                MathEvent(x, y);
            }
        }
          
    }
}
