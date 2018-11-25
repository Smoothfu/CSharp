using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp291
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearch(1000000);
            Console.ReadLine();
        }

        static void FindPrimes(int num)
        {
            if(num<=1)
            {
                return;
            }

            
            List<int> primeList = new List<int>();
            
            for (int i=2;i<=num;i++)
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

                if (isPrime)
                {
                    primeList.Add(i);
                }
            }

            foreach(int i in primeList)
            {
                Console.WriteLine(i);
            }
        }

        static void BinarySearch(int count)
        {
           List<int> intList=new List<int>(Enumerable.Range(1, count));
            intList.ForEach(x =>
            {
                Console.Write(x+"\t");
            });           
        }
    }
}
