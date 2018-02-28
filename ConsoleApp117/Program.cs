using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp117
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 90, 89, 4343, 4358, 23489, 8934, -43434, 425890, 8997989, 437894, 789434, 4378923, 7892393, 7893443, 7842333, 678394524, 436328792, 345423434 };
            Console.WriteLine("Before sort: ");
            foreach(var a in arr)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n\n\n");

            BubbleSort(arr);
            Console.ReadLine();
        }

        static void BubbleSort(int[] arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }

            for(int i=0;i<arr.Length;i++)
            {
                for(int j=i+1;j<arr.Length;j++)
                {
                    if(arr[i]>arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            Console.WriteLine("The BubbleSort:");
            foreach(var a in arr)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("\n\n\n");
        }
    }
}
