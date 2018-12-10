using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp304
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random rnd = new Random();
            for(int i=0;i<100;i++)
            {
                arr[i] = rnd.Next(1,10000000);
            }

            SelectionSort(arr);
            Console.ReadLine();
        }

        static void SelectionSort(int[] arr)
        {
            if(arr==null ||!arr.Any())
            {
                return;
            }

            Console.WriteLine("Initial sort: \n" + string.Join("\t", arr) + "\n");
            for(int i=0;i<arr.Length;i++)
            {
                int minIndex = i;                
                for(int j=i+1;j<arr.Length;j++ )
                {
                    if(arr[j]<arr[minIndex])
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
            }

            Console.WriteLine("\nAfter selection sort:\n " + string.Join("\t", arr));

        }
    }
}
