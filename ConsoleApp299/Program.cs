using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace ConsoleApp299
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[100000];
            BuildArray(nums);
            TimeSpan startTime;
            TimeSpan duration;
            startTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;  
            DisplayNums(nums);
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startTime);
            Console.WriteLine("\n\nTime: " + duration.TotalSeconds);
            Console.ReadLine();
        }

        static void BuildArray(int[] arr)
        {
            for(int i=0;i<=99999;i++)
            {
                arr[i] = i;
            }
        }
        static void DisplayNums(int[] arr)
        {
            for(int i=0;i<=arr.GetUpperBound(0);i++)
            {
                Console.Write(arr[i] + "\t");
            }
        }
        static void GenericT()
        {
            string name1 = "Fred0";
            string name2 = "Fred1";
            Console.WriteLine("Before swap:");
            Console.WriteLine("name1={0}", name1);
            Console.WriteLine("name2={0}", name2);

            Console.WriteLine("\nAfter swap:");
            Swap<string>(ref name1, ref name2);
            Console.WriteLine("name1={0}", name1);
            Console.WriteLine("name2={0}", name2);

            int num1 = 100;
            int num2 = 200;
            Console.WriteLine("\nBefore swap:");
            Console.WriteLine("num1={0}", num1);
            Console.WriteLine("num2={0}", num2);
            Swap<int>(ref num1, ref num2);
            Console.WriteLine("\nAfter swap:");
            Console.WriteLine("num1={0}", num1);
            Console.WriteLine("num2={0}", num2);
        }
        static void Swap<T>(ref T val1,ref T val2)
        {
            T temp;
            temp = val1;
            val1 = val2;
            val2 = temp;
        }
        static void AbstractCollectionBase()
        {
            Collection names = new Collection();
            names.Add("Fred0");
            names.Add("Fred1");
            names.Add("Fred2");
            names.Add("Fred3");
            foreach (object name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n\nNumber of names: " + names.Count());
            names.Remove("Fred2");
            Console.WriteLine("\n\nNumber of names: " + names.Count());
            names.Clear();
            Console.WriteLine("\n\nNumber of names: " + names.Count());
        }
        static void HashTableKeyValueDictionaryEntry()
        {
            Hashtable hashtable = new Hashtable();
            DictionaryEntry dee = new DictionaryEntry();
            dee.Key = Guid.NewGuid();
            dee.Value = "Fred";
            hashtable[0] = dee;
            for (int i = 0; i < 10; i++)
            {
                string name = "Fred" + i;
                hashtable.Add(Guid.NewGuid(), name);
            }

            foreach (DictionaryEntry de in hashtable)
            {
                Console.WriteLine(de.Key + "\t" + de.Value);
            }
        }
        static void HashSetDistictValue()
        {
            HashSet<int> intHashSet = new HashSet<int>();
            intHashSet.Add(10);
            intHashSet.Add(20);
            Console.WriteLine(intHashSet.Count);
            Parallel.ForEach(intHashSet, x =>
            {
                Console.WriteLine(x);
            });
        }
        static void QueueFirstInFirstOut()
        {
            Queue<int> intQueue = new Queue<int>();
            Random rnd = new Random();
            Console.WriteLine("Enqueue Order:\n");
            for (int i = 0; i < 10; i++)
            {
                int tempValue = rnd.Next(0, int.MaxValue);
                intQueue.Enqueue(tempValue);
                Console.Write(tempValue + "\t");
            }

            Console.WriteLine("\n\nDequeue Order:\n");
            while (intQueue.Count > 0)
            {
                Console.Write(intQueue.Dequeue() + "\t");
            }
        }
        static void StackFirstInLastOut()
        {
            Stack<int> intStack = new Stack<int>();
            Random rnd = new Random();
            Console.WriteLine("The push in order:\n");
            for (int i = 0; i < 10; i++)
            {
                int tempValue = rnd.Next(0, int.MaxValue);
                intStack.Push(tempValue);
                Console.Write(tempValue + "\t");
            }

            Console.WriteLine("\nThe pop up order:\n");
            while (intStack.Count > 0)
            {
                Console.Write(intStack.Pop() + "\t");
            }
        }
        static void ReadNumber()
        {
            int num;
            string sNum;
            Console.Write("Enter a number: ");
            sNum = Console.ReadLine();
            num = Int32.Parse(sNum);
            Console.WriteLine();
            Console.WriteLine(num);
        }
        static void GetSingleton()
        {
            Singleton instance = Singleton.GetSingletonInstance();
            Console.WriteLine(instance.GetType().Name);
        }
        static void OutputTime()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }
    }

    public  sealed  class Singleton
    {
        private static Singleton Instance;
        private Singleton()
        { 
        }

        private static object objLock = new object();

        public static Singleton GetSingletonInstance()
        {
            lock(objLock)
            {
                if(Instance==null)
                {
                    Instance = new Singleton();
                }
            }
            return Instance;
        }
    }

    public class Collection : CollectionBase
    {
        public void Add(object item)
        {
            InnerList.Add(item);
        }

        public void Remove(object item)
        {
            InnerList.Remove(item);
        }

        public new void Clear()
        {
            InnerList.Clear();
        }

        public new int Count()
        {
            return InnerList.Count;
        }
    }

    public class Node<T>
    {
        T data;
        Node<T> link;
        public Node(T data,Node<T> link)
        {
            this.data = data;
            this.link = link; 
        }
    }
}
