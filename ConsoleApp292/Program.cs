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
            int[] arr = new int[10];
            Random rnd = new Random();
            for(int i=0;i<10;i++)
            {
                arr[i] = rnd.Next(1, 1000);
            }
            Console.WriteLine("The original array:\n");
            arr.All(x =>
            {
                Console.Write(x + "\t");
                return true;
            });

            Array.Sort(arr);
            Console.WriteLine("\n\n\nThe sorted array:\n");
            arr.All(x =>
            {
                Console.Write(x + "\t");
                return true;
            });
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
