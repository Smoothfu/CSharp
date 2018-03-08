using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp127
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);

            for(int i=0;i<10;i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }

            for(int i=0;i<10;i++)
            {
                threads[i].Start();
            }

            //block main thread until all other threads have ran to completion.
            foreach(var t in threads)
            {
                t.Join();
            }
            Console.ReadLine();
        }
        
        public static void RunMe()
        {
            Console.WriteLine("RunMe called!\n");
        }        
        
    }

    class Account
    {
        private object thisLock = new object();
        int balance;

        Random rnd = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int Withdraw(int amount)
        {
            //This condition never is true unless the lock statement is copleted out.
            if(balance<0)
            {
                throw new Exception("Negative Balance!\n");
            }

            //Comment out the next line to see the effect of leaving out the lock keyword.
            lock(thisLock)
            {
                if(balance>=amount)
                {
                    Console.WriteLine("Balance before Withdrawl: {0}\n", balance);
                    Console.WriteLine("Amount to Widthdraw: {0}\n", amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Widthdrawl: {0}\n", balance);
                    return amount;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void DoTransactions()
        {
            for(int i=0;i<100;i++)
            {
                Withdraw(rnd.Next(1, 100));
            }
        }
    }
}
