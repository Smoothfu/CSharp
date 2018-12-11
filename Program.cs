using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp306
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder = ConvertBits(100000000);
            Console.WriteLine(stringBuilder.ToString());
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

        static StringBuilder ConvertBits(int val)
        {
            int dispMask = 1 << 31;
            StringBuilder bitBuffer = new StringBuilder(35);
            for(int i=1;i<=32;i++)
            {
                if((val&dispMask)==0)
                {
                    bitBuffer.Append("0");
                }
                else
                {
                    bitBuffer.Append("1");
                }
                val <<= 1;
                if((i%8)==0)
                {
                    bitBuffer.Append(" ");
                }
            }

            return bitBuffer;
        }
    }
}
