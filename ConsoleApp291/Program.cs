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
            BubbleySearch(100);
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

        static void BubbleySearch(int count)
        {
            int[] arr = new int[count];
            Random rnd = new Random();
            for(int i=0;i<count;i++)
            {
                arr[i] = rnd.Next(1, 10000);
            }

            Console.WriteLine("The original sequence is:\n");
            foreach(var i in arr)
            {
                Console.Write(i + "\t");
            }

            Console.WriteLine("\n\n\n\n\nThe ordered result is:");
            for(int i=0;i<arr.Length;i++)
            {
                for(int j=i+1;j<arr.Length; j++)
                {
                    if(arr[i]>arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            foreach(int i in arr)
            {
                Console.Write(i + "\t");
            }
        }
    }
}
