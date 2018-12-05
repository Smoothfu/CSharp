using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp300
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            int[] arr = { 1, 2, 3 };
            al.AddRange(arr);
            al.Add(true);
            al.Add("d");
            al.Add("C");
            al.Add(100032);
            al.Add(787);
            Console.WriteLine("This is the original order:\n");
            foreach(var a in al)
            {
                Console.Write(a+"\t");
            }

            Console.WriteLine("\n\n\nThis is the reversed order:\n");
            al.Reverse();
            foreach (var a in al)
            {
                Console.Write(a + "\t");
            }
            Console.ReadLine();
        }

        static void JaggedArray()
        {
            int[] Jan = new int[31];
            int[] Feb = new int[29];
            int[][] sales = new int[][] { Jan, Feb };
            int month, day, total;
            double average = 0.00;
            sales[0][0] = 41;
            sales[0][1] = 30;
            sales[0][0] = 41;
            sales[0][1] = 30;
            sales[0][2] = 23;
            sales[0][3] = 34;
            sales[0][4] = 28;
            sales[0][5] = 35;
            sales[0][6] = 45;
            sales[1][0] = 35;
            sales[1][1] = 37;
            sales[1][2] = 32;
            sales[1][3] = 26;
            sales[1][4] = 45;
            sales[1][5] = 38;
            sales[1][6] = 42;

            for (month = 0; month <= 1; month++)
            {
                total = 0;
                for (day = 0; day <= 6; day++)
                {
                    total += sales[month][day];
                }
                average = total / 7;
                Console.WriteLine("Average sales for month: " + month + " :" + average);
            }
        }
        static int sumNums(params int[] arr)
        {
            int sum = 0;
            for(int i=0;i<=arr.GetUpperBound(0);i++)
            {
                sum += arr[i];
            }
            return sum; 
        }
        static void MultiDimensionArray()
        {
            int[,] grades = new int[,]
            {
                {1,82,74,89,100},
                {2,93,96,85,86},
                {3,83,72,95,89},
                {4,91,98,79,88}
            };

            int last_grade = grades.GetUpperBound(1);
            double average = 0;
            int total;
            int last_Student = grades.GetUpperBound(0);
            for (int row = 0; row <= last_Student; row++)
            {
                total = 0;
                for (int col = 0; col <= last_grade; col++)
                {
                    total += grades[row, col];
                }

                average = total / last_grade;
                Console.WriteLine("Average :" + average);
            }


            int rank = grades.Rank;
            Console.WriteLine("The rank of grades is " + rank);
        }
        static void ArrayGetLength()
        {
            string[] names = new string[10];
            //names.SetValue("Fred1", 0);
            //names.SetValue("Fred2", 1);
            //names.SetValue("Fred3", 2);
            //names.SetValue("Fred4", 3);
            //names.SetValue("Fred5", 4);
            //names.SetValue("Fred6", 5);
            //names.SetValue("Fred1", 6);
            //names.SetValue("Fred2", 7);
            //names.SetValue("Fred3", 8);            

            if (names != null && names.Any())
            {
                for (int i = 0; i < names.Count(); i++)
                {
                    Console.WriteLine(names[i]);
                }
            }

            int arrLength = names.Length;
            Console.WriteLine("The length of the array is {0}\n", arrLength);
            int elementsNum = names.GetLength(0);
            Console.WriteLine("GetLength():{0}\n", elementsNum);

            int arrayRank = names.Rank;
            Console.WriteLine("The rank of names is :{0}\n", arrayRank);

            Type typeName = names.GetType();
            if (typeName.IsArray)
            {
                Console.WriteLine("The names array type  is {0}\n", typeName);
            }
            else
            {
                Console.WriteLine("Not an array!\n");
            }
            Console.WriteLine("The type of names is :{0}\n", typeName);
        }
        static void ArrayListSizeChangeDynamically()
        {
            ArrayList al = new ArrayList();
            al.Capacity = 5;
            Random rnd = new Random();
            for (int i = 0; i < 1000002; i++)
            {
                al.Add(rnd.Next(0, 10000002));
            }
            Console.WriteLine(al.Capacity);
        }
        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
            int countNum = 0;

            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for (int j=2;j<=Math.Sqrt(i);j++)
                {
                    ++countNum;
                    if (i%j==0)
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

          
            if(primeList!=null && primeList.Any())
            {
                foreach(int i in primeList)
                {
                    Console.Write(i + "\t");
                }
            }

            Console.WriteLine("\n\nThis has computed {0}  times", countNum);
        }
    }
}
