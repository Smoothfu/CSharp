using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp302
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for(int i=0;i<10;i++)
            {
                arr[i] = rnd.Next(1, 100000);
            }
            SelectionSort(arr);
            Console.ReadLine();
        }

        static void SelectionSort(int[] arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }

            Console.WriteLine("The original array order:");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }
            Console.WriteLine();
            for(int i=0;i<arr.Length;i++)
            {
                int minIndex = i;
                for(int j=i+1;j<arr.Length;j++)
                {
                    if(arr[minIndex]>arr[j])
                    {
                        minIndex = j;
                    }
                }

                
                if(minIndex!=i)
                {
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;
                }
                Console.WriteLine("\nThe {0} loop result:",i+1);
                foreach (int a in arr)
                {
                    Console.Write(a + "\t");
                }
                 
                Console.WriteLine();
                Console.ReadLine();
            }

            Console.WriteLine("\nAfter selection sort,the array order:");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }
        }
    }
}
