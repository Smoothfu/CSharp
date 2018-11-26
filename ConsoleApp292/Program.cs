using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp292
{
    class Program
    {
        static void Main(string[] args)
        {
            FindPrimes(100);
            Console.ReadLine();
        }

        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
            if(num<=0)
            {
                return;
            }

            
            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for (int j=2;j<=Math.Sqrt(i);j++)
                {
                    if(i%j==0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime)
                {
                    primeList.Add(i);
                }
            }

            primeList.ForEach(x =>
            {
                Console.Write(x + "\t");
            });
        }
    }
}
