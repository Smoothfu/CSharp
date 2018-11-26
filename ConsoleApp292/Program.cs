using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp292
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueOrder();
            Console.ReadLine();
        }

        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
            if(num<=0)
            {
                return;
            }

            
            for(int i=2;i<=num;i++)
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

                if(isPrime)
                {
                    primeList.Add(i);
                }
            }

            primeList.ForEach(x =>
            {
                Console.Write(x + "\t");
            });
        }
        static void ArraySample()
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(1, 1000);
            }
            Console.WriteLine("The original array:\n");
            arr.All(x =>
            {
                Console.Write(x + "\t");
                return true;
            });

            Array.Sort(arr);
            Console.WriteLine("\n\n\nThe sorted array:\n");
            arr.All(x =>
            {
                Console.Write(x + "\t");
                return true;
            });
        }
        static void Top10Languages()
        {
            string[] top10Language = new string[] { "Javascript", "Java", "Python", "PHP", "C++", "C#", "TypeScript", "Shell", "C", "Ruby" };

            top10Language.All(x =>
            {
                Console.WriteLine(x);
                return true;
            });
        }
        static void IntTryParse()
        {
            int num;
            string str;
            Console.Write("Enter a number: ");
            str = Console.ReadLine();
            if (int.TryParse(str, out num))
            {
                Console.WriteLine("You entered num is {0}\n", num);
            }
        }
        static void ArrayListCapacityExpandAutomobile()
        {
            ArrayList al = new ArrayList();
            al.Capacity = 3;
            for (int i = 0; i < 10; i++)
            {
                al.Add(i);
            }
            Console.WriteLine(al.Capacity);
        }
        static void StackOrder()
        {
            Stack<int> intStack = new Stack<int>();
            Console.WriteLine("The pushed order:");
            for (int i = 0; i < 10; i++)
            {
                intStack.Push(i);
                Console.Write(i + "\t");
            }

            Console.WriteLine("\n\n\n\n\nThe popped up order:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(intStack.Pop() + "\t");
            }
        }
        static void QueueOrder()
        {
            Queue<int> intQueue = new Queue<int>();

            Console.WriteLine("The enqueue order: ");
            for (int i = 0; i < 10; i++)
            {
                intQueue.Enqueue(i);
                Console.Write(i + "\t");
            }

            Console.WriteLine("\n\n\n\n\nThe dequeue order: ");
            while (intQueue.Count > 0)
            {
                Console.Write(intQueue.Dequeue() + "\t");
            }
        }
    }
}
