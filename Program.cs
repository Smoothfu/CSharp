﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp300
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            al.Capacity = 5;
            Random rnd = new Random();
            for(int i=0;i<1000002;i++)
            {
                al.Add(rnd.Next(0, 10000002));
            }
            Console.WriteLine(al.Capacity);

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
                    ++countNum;
                    if (i%j==0)
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
