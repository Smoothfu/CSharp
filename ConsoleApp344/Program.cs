using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp344
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTableExample2();
            Console.ReadLine();
        }

        static void HashTableExample2()
        {
            Hashtable hashtable1 = new Hashtable();
            Hashtable hashTable2 = new Hashtable(50);
            Hashtable hashTable3 = new Hashtable(25, 0.3f);
        }

        static void HashCodeDistinct()
        {
            List<int> hashCodeList = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int temp = rnd.Next(0, Int32.MaxValue);
                hashCodeList.Add(temp.GetHashCode());
            }

            var distinct = (from str in hashCodeList select str).Distinct();

            Console.WriteLine($"The hashCodeList's count is {hashCodeList.Count}," +
                $"distinct list count is {distinct.Count()}");
        }
        static void HashTableExample()
        {
            string[] names = new string[99];
            string name;
            string[] someNames = new string[]
            {
                "David","Jennifer","Donnie","Mayo","Raymond","Bernica","Mike","Clayton","Beata","Michael"
            };
            int hashVal;
            for (int i = 0; i < 10; i++)
            {
                name = someNames[i];
                hashVal = SimpleHash(name, names);
                names[hashVal] = name;
            }
            ShowDistrib(names);
        }
        static int SimpleHash(string str,string[] arr)
        {
            int tot = 0;
            char[] cName;
            cName = str.ToCharArray();
            for(int i=0;i<cName.Length;i++)
            {
                tot += (int)cName[i];
            }
            return tot % arr.Length;
        }
        static void ShowDistrib(string[] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                if(null!=arr[i])
                {
                    Console.WriteLine(i + "\t" + arr[i]);
                }
            }
        }
    }

    public class BucketHash
    {
        private const int SIZE = 101;
        ArrayList[] data;
        public BucketHash()
        {
            data = new ArrayList[SIZE];
            for(int i=0;i<=SIZE-1;i++)
            {
                data[i] = new ArrayList(4);
            } 
        }

        public int Hash(string str)
        {
            long tot = 0;
            char[] charArr;
            charArr = str.ToCharArray();
            for(int i=0;i<=str.Length-1;i++)
            {
                tot += 37 * tot + (int)charArr[i];
            }
            tot = tot % data.Length;
            if(tot<0)
            {
                tot += data.Length;
            }
            return (int)tot;
        }

        public void Insert(string item)
        {
            int hash_Value;
            hash_Value = Hash(item);

            if(!data[hash_Value].Contains(item))
            {
                data[hash_Value].Add(item);
            }
        }

        public void Remove(string item)
        {
            int hash_Value;
            hash_Value = Hash(item);
            if(data[hash_Value].Contains(item))
            {
                data[hash_Value].Remove(item);
            }
        }
    }
}
