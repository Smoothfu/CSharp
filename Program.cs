using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp306
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
             
            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for(int j=2;j<=Math.Sqrt(i);j++)
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

            Console.WriteLine("\nThe primes below {0} num is\n " + string.Join("\t", primeList), num);
        }
    }
}
