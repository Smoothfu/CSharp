using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp301
{
    class Program
    {
        static void Main(string[] args)
        {
            CArray arr = new CArray(100);
            Random rnd = new Random(100);
            arr.DisplayElements();
            Console.ReadLine();
        }

        static void ArrayListDynamicalyIncreaseSize()
        {
            ArrayList al = new ArrayList();
            al.Add(1);
            al.Add(true);
            al.Add(1.1);
            al.Add('c');
            al.Add("Seeking truth");


            if (al != null && al.Count > 0)
            {
                foreach (var a in al)
                {
                    Console.WriteLine(a);
                }
            }
        }

        static void BubbleSortAsc()
        {
            Random rnd = new Random();
            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                int tempValue = rnd.Next(1, 1000000000);
                arr[i] = tempValue;
            }
            if (arr==null || !arr.Any())
            {
                return;
            }

            Console.WriteLine("Before sorting,the original order:");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }
            for (int i=0;i<arr.Length;i++)
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

            Console.WriteLine("\n\nAfter sorting in order ascending:");
            foreach(int a in arr)
            {
                Console.Write(a+"\t");
            }            
        }
    }

    class CArray
    {
        private int[] arr;
        private int upper;
        private int numElements;

        public CArray(int size)
        {
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }
        
        public void Insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }

        public void DisplayElements()
        {
            for(int i=0;i<=upper;i++)
            {
                Console.Write(arr[i] + "\t");
            }
        }

        public void Clear()
        {
            for(int i=0;i<=upper;i++)
            {
                arr[i] = 0;                
            }
            numElements = 0;
        }
    }
}
