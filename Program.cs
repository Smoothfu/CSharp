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
            //int[] arr = new int[10];
            //Random rnd = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    arr[i] = rnd.Next(1, 10000000);
            //}

            int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190 };
            RecursiveBinSearch(arr, 150, 0, arr.Length - 1);
            
          
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

        static int BinarySearch(int[] arr,int target)
        {
            if(arr==null || !arr.Any())
            {
                return -1;
            }

            Array.Sort(arr);
            int low = 0, high = arr.Length - 1;
            while(low<=high)
            {
                int mid = (low + high) / 2;
                if(arr[mid]==target)
                {
                    return mid + 1;
                }

                if(arr[mid]>target)
                {
                    high = mid - 1;
                }

                if(arr[mid]<target)
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        static void FindMin(int[] arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }
            Console.WriteLine("The initial array is \n" + string.Join("\t", arr) + "\n");
            int min = arr[0];
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]<min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine("\nThe minimum element in this array is  " + min);
        }

        static void FindMax(int[]arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }

            Console.WriteLine("The initial order: \n" + string.Join("\t", arr));
            int max = arr[0];
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]>max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine("\nThe max in array is " + max);
        }

        static int RecursiveBinSearch(int[] arr,int target,int low,int high)
        {            
            if(arr==null ||!arr.Any())
            {
                return -1;
            }

            else
            {
                int mid;
                mid = (low + high) / 2;
                if(target>arr[mid])
                {
                    RecursiveBinSearch(arr, target,mid+1,high);
                }
                else if (target==arr[mid])
                {
                    Console.WriteLine("The target value in the arr's index is {0}\n ", mid + 1);
                    return mid;
                }
                else
                {
                    RecursiveBinSearch(arr, target,low,mid-1);
                }
            }
            return -1;
        }
    }
}
