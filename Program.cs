using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp300
{
    class Program
    {
        static void Main(string[] args)
        {
            FindPrimes(1000);

            Console.ReadLine();
        }

        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
            int countNum = 0;

            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for (int j=2;j<=Math.Sqrt(i);j++)
                {
                    if(i%j==0)
                    {
                        ++countNum;
                        isPrime = false;
                        break;
                    }                 
                }

               if(isPrime)
                {
                    primeList.Add(i);
                }
            }

          
            if(primeList!=null && primeList.Any())
            {
                foreach(int i in primeList)
                {
                    Console.Write(i + "\t");
                }
            }

            Console.WriteLine("\n\nThis has computed {0}  times", countNum);
        }
    }
}
