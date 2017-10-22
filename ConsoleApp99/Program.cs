using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp99
{
    class Program
    {
        static void Main(string[] args)
        {
            BookShop book = new BookShop();
            //create 2 thread to access the sale meanwhile
            Thread thread1 = new Thread(new ThreadStart(book.Sale));
            Thread thread2 = new Thread(new ThreadStart(book.Sale));

            //start the thread
            thread1.Start();
            thread2.Start();
            Console.ReadLine();
        }
    }

    class BookShop
    {
        //the remaining book amount
        public int num = 1;
        public void Sale()
        {
            lock (this)
            {
                int temp = num;
                if (temp > 0)
                {
                    Thread.Sleep(1000);
                    num -= 1;
                    Console.WriteLine("Saled one book,the remaining amout is {0}", num);
                }
                else
                {
                    Console.WriteLine("Empty");
                }
            }           
        }
    }
}
