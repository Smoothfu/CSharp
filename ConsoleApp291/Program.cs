using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp291
{
    class Program
    {
        static void Main(string[] args)
        {
            StructSample();
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

        static int  BinarySearch(int[] arr,int target)
        {
            if(arr==null || !arr.Any())
            {
                return -1;
            }
            int high = arr.Length-1;        
            
            Array.Sort(arr);
            Console.WriteLine("The original data is :\n");
            foreach(int a in arr)
            {
                Console.Write(a + "\t");
            }
            Console.WriteLine("\n\n\n");
            int low = 0;                  

            while(low<=high)
            {
                int mid = (low + high) / 2;
                if (target == arr[mid])
                {
                    return mid;
                }
                if (arr[mid]>target)
                {
                    high = mid-1;
                }
                if(arr[mid]<target)
                {
                    low = mid + 1;
                }
            }
            return -1;
        }

        static void GetAllFiles()
        {
            string path = @"D:\C";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] allFiles = dir.GetFiles("*",SearchOption.AllDirectories);
            if(allFiles!=null && allFiles.Any())
            {
               foreach(var file in allFiles)
                {
                    Console.WriteLine(file.FullName);
                }

                Console.WriteLine("\n\n\nThere are totally {0} files in {1}\n", allFiles.Count(), path);
            }
        }

        static void StackOrder(int count)
        {
            if (count <= 0)
            {
                return;
            }
            Stack<int> intStack = new Stack<int>();
            Random rnd = new Random();
            for(int i=0;i<count;i++)
            {
                intStack.Push(i);
            }

            Console.WriteLine("There are {0} totally numbers in stack", intStack.Count);
            while(intStack.Count>0)
            {
                Console.Write(intStack.Pop()+"\t");
            }

        }

        static void QueueOrder(int count)
        {
            if(count<=0)
            {
                return;
            }

            Queue<int> intQueue = new Queue<int>();
            for(int i=0;i<count;i++)
            {
                intQueue.Enqueue(i * 100);
            }

            while(intQueue.Count>0)
            {
                Console.WriteLine(intQueue.Dequeue());
            }
        }

        static void StructSample()
        {
            PersonStruct pStruct = new PersonStruct(31, "Floomberg");
            Console.WriteLine(pStruct.Age);
            Console.WriteLine(pStruct.Name);
        }
    }

    public struct PersonStruct
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public PersonStruct(int age,string name)
        {
            Age = age;
            Name = name;
        }
    }
}
