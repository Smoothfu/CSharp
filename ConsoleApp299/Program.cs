using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp299
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSetDistictValue();
            Console.ReadLine();
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
}
