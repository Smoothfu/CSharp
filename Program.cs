using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp306
{
    class Program
    {
        static void Main(string[] args)
        {
            StringToCharArray();
            Console.ReadLine();
        }

        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
             
            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for(int j=2;j<=Math.Sqrt(i);j++)
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

            Console.WriteLine("\nThe primes below {0} num is\n " + string.Join("\t", primeList), num);
        }

        static StringBuilder ConvertBits(int val)
        {
            int dispMask = 1 << 31;
            StringBuilder bitBuffer = new StringBuilder(35);
            for(int i=1;i<=32;i++)
            {
                if((val&dispMask)==0)
                {
                    bitBuffer.Append("0");
                }
                else
                {
                    bitBuffer.Append("1");
                }
                val <<= 1;
                if((i%8)==0)
                {
                    bitBuffer.Append(" ");
                }
            }

            return bitBuffer;
        }

        static void BitShift()
        {
            int i = 10;
            int j = 10 << 3;
            int k = 10 >> 2;
            Console.WriteLine("left shift: "+j);
            Console.WriteLine("right shitf: " + k);
        }

        static void BitArrayExample()
        {
            BitArray ba1 = new BitArray(5);
            BitArray ba2 = new BitArray(5, false);
            byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
            BitArray ba3 = new BitArray(myBytes);
            bool[] myBools = new bool[5] { true, false, true, true, false };
            BitArray ba4 = new BitArray(myBools);
            int[] myInts = new int[5] { 6, 7, 8, 9, 10 };
            BitArray ba5 = new BitArray(myInts);

            //Displays the properties and values of the BitArrays
           
            Console.WriteLine("ba1,default false,Count:{0},Length:{1}\n", ba1.Count, ba1.Length);
           

            Console.WriteLine("ba2,false,Count:{0},Length:{1}\n", ba2.Count, ba2.Length);
             

            Console.WriteLine("ba3,byte,Count:{0},Length:{1}\n", ba3.Count, ba3.Length);

            Console.WriteLine("ba4,bool,Count:{0},Length:{1}\n", ba4.Count, ba4.Length); 

            Console.WriteLine("ba5,int,Count:{0},Length:{1}\n", ba5.Count, ba5.Length); 
        }

        public static void PrintValues(IEnumerable myList,int myWidth)
        {
            int i = myWidth;
            foreach(object obj in myList)
            {
                if(i<=0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.WriteLine("{0,8}", obj);
            }
            Console.WriteLine();
        }

        static void ByteBitArray()
        {
            byte[] byteSet = new byte[] { 1, 2, 3, 4, 5 };
            BitArray bitSet = new BitArray(byteSet);
            
            for (int i=0;i<bitSet.Count;i++)
            {
                Console.Write(bitSet.Get(i)+"\t");
            }
        }

        static void BitGet()
        {
            int bits;
            string[] binNumber = new string[8];
            int binary;
            byte[] byteSet = new byte[] { 1, 2, 3, 4, 5 };
            BitArray bitSet = new BitArray(byteSet);
            bits = 0;
            binary = 7;
            for(int i=0;i<bitSet.Count;i++)
            {
                if(bitSet.Get(i)==true)
                {
                    binNumber[binary] = "1";
                }
                else
                {
                    binNumber[binary] = "0";
                }
                bits++;
                binary--;

                if((bits%8)==0)
                {
                    binary = 7;
                    bits = 0;
                    Console.WriteLine(string.Join("", binNumber));
                }
            }
        }
        static void BitArraySet()
        {
            BitArray bits = new BitArray(100);
            for(int i=0;i<100;i++)
            {
                bool bitValue = i % 2 == 0 ? true : false;
                bits.Set(i, bitValue);
            }

            Console.WriteLine("The BitArray Set()");
            if(bits!=null)
            {
                 for(int i=0;i<bits.Length;i++)
                {
                    Console.Write(bits[i] + "\t");
                }
            }

            Console.WriteLine("\n\n\n\n\n");

            Console.WriteLine("The BitArray.SetAll()");
            BitArray bitTrue = new BitArray(100);
            bitTrue.SetAll(true);
            for(int i=0;i<100;i++)
            {
                Console.Write(bitTrue[i] + "\t");
            }
        }

        static void StringToCharArray()
        {
            string str = "the quick brown fox jumped over the lazy dog";
            char[] charArr = str.ToCharArray();
            var nonWhiteSpaceCharArr = from c in charArr
                                       where !char.IsWhiteSpace(c)
                                       select c;
            Console.WriteLine(string.Join("\t", nonWhiteSpaceCharArr));
        }
    }
}
