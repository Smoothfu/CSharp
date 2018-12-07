using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp303
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for(int i=0;i<10;i++)
            {
                arr[i] = rnd.Next(10, 1000);
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

            Console.Write("Initial array: ");
            Console.WriteLine(string.Join("\t", arr));
            
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

                if(i!=minIndex)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            Console.Write("\nAfter sort: ");
            Console.WriteLine(string.Join("\t", arr));
        }
    }
}
