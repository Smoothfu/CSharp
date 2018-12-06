using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace ConsoleApp301
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime dt = DateTime.Now;
            //DateTime dtFuture = dt.AddSeconds(10);
            //Timer selectionSort1SecondInterval = new Timer(x =>
            //{
            //    if(DateTime.Now<dtFuture)
            //    {
            //        SelectionSort();
            //    }

            //}, null, 0, 1000);

            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int rndValue = rnd.Next(1, 1000);
                arr[i] = rndValue;
            }
            SelectSort(arr);

            //在擂台下面，台上的生死更你没关，你只不过是看个乐子；可是站在这里头，你只能赢，不能输！
            Console.ReadLine();
        }

        static void SelectSort(int []arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }

            Console.WriteLine("The original arr order:");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }

            for(int i=0;i<arr.Length;i++)
            {
                int minIndex = i;
                for(int j=i+1;j<arr.Length;j++)
                {
                    if (arr[minIndex] > arr[j])
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

            Console.WriteLine("\n\n\nAfter selection sort:");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }
        }
        static void SelectionSort()
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int rndValue = rnd.Next(1, 1000);
                arr[i] = rndValue;
            }
            if (arr==null || !arr.Any())
            {
                return;
            }

            Console.WriteLine("\nThe orignal order:");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }
            
            //Advance the position through the entire array.
            //could do i<arr.Length because single element is also min element.
            for(int i=0;i<arr.Length;i++)
            {
                //find the min element in the unsorted a[i,...,arr.Length-1]
                //assume the min is the first element

                int minIndex = i;
                //test against elements after i to find the smallest

                for (int j=i+1;j<arr.Length;j++)
                {
                    //if this element is less,then it is the new minimum.
                   if(arr[minIndex]>arr[j])
                    {  
                        //found new minimum,remember its index
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

            Console.WriteLine("\n\n\nAfter sorting,the array order:");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }
            Console.WriteLine("\n\n");
        }
        static void RandomPseduo()
        {
            CArray arr = new CArray(10);
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                arr.Insert((int)(rnd.NextDouble() * 100));
            }
            arr.DisplayElements();
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
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
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
                System.Diagnostics.Debug.Write(arr[i]+"\t");
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
